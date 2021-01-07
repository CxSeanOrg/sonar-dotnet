﻿/*
 * SonarAnalyzer for .NET
 * Copyright (C) 2015-2021 SonarSource SA
 * mailto: contact AT sonarsource DOT com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SonarAnalyzer.Common;
using SonarAnalyzer.Helpers;

namespace SonarAnalyzer.Rules.VisualBasic
{
    [DiagnosticAnalyzer(LanguageNames.VisualBasic)]
    [Rule(DiagnosticId)]
    public sealed class DeclareTypesInNamespaces : DeclareTypesInNamespacesBase
    {
        private static readonly DiagnosticDescriptor rule =
            DiagnosticDescriptorBuilder.GetDescriptor(DiagnosticId, MessageFormat, RspecStrings.ResourceManager);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(rule);

        protected override SyntaxToken GetTypeIdentifier(SyntaxNode declaration)
        {
            switch (declaration.Kind())
            {
                case SyntaxKind.EnumStatement:
                    return ((EnumStatementSyntax)declaration).Identifier;
                case SyntaxKind.ClassStatement:
                case SyntaxKind.InterfaceStatement:
                case SyntaxKind.StructureStatement:
                    return ((TypeStatementSyntax)declaration).Identifier;
                default:
                    return default(SyntaxToken);
            }
        }

        protected override bool IsInnerTypeOrWithinNamespace(SyntaxNode declaration, SemanticModel semanticModel)
        {
            switch (declaration.Parent.Parent.Kind())
            {
                case SyntaxKind.ClassBlock:
                case SyntaxKind.InterfaceBlock:
                case SyntaxKind.StructureBlock:
                case SyntaxKind.NamespaceBlock:
                    return true;
            }

            // If declaration is an outer type that is not within a namespace block,
            // make sure there is no Root Namespace set in the project
            var typeSymbol = (INamedTypeSymbol)semanticModel.GetDeclaredSymbol(declaration);
            return typeSymbol == null ||
                !typeSymbol.ContainingNamespace.IsGlobalNamespace;
        }

        protected override void Initialize(SonarAnalysisContext context) =>
            context.RegisterSyntaxNodeActionInNonGenerated(
                GetAnalysisAction(rule),
                SyntaxKind.ClassStatement,
                SyntaxKind.StructureStatement,
                SyntaxKind.EnumStatement,
                SyntaxKind.InterfaceStatement);
    }
}
