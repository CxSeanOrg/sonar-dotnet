/*
 * SonarSource :: .NET :: Shared library
 * Copyright (C) 2014-2020 SonarSource SA
 * mailto:info AT sonarsource DOT com
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
package org.sonarsource.dotnet.shared.plugins;

import java.io.IOException;
import java.net.URI;
import java.nio.file.Paths;
import java.util.Arrays;
import java.util.HashSet;
import org.junit.Before;
import org.junit.Rule;
import org.junit.Test;
import org.sonar.api.SonarEdition;
import org.sonar.api.SonarQubeSide;
import org.sonar.api.batch.fs.InputFile;
import org.sonar.api.config.PropertyDefinitions;
import org.sonar.api.config.internal.MapSettings;
import org.sonar.api.internal.SonarRuntimeImpl;
import org.sonar.api.utils.Version;
import org.sonar.api.utils.log.LogTester;
import org.sonar.api.utils.log.LoggerLevel;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class GeneratedFileFilterTest {

  @Rule
  public LogTester logs = new LogTester();

  private AbstractSolutionConfiguration defaultConfiguration;

  @Before
  public void setUp() {
    // by default, analyzeGeneratedCode is set to false
    AbstractPropertyDefinitions definitions = new AbstractPropertyDefinitions(
      "cs",
      "C#",
      ".cs",
      SonarRuntimeImpl.forSonarQube(Version.create(7, 9), SonarQubeSide.SERVER, SonarEdition.COMMUNITY)) {
    };
    MapSettings settings = new MapSettings(new PropertyDefinitions(definitions.create()));
    defaultConfiguration = new AbstractSolutionConfiguration(settings.asConfig(), "cs") { };
  }

  @Test
  public void accept_returns_false_for_autogenerated_files() throws IOException {
    // Arrange
    GeneratedFileFilter filter = createFilter(URI.create("autogenerated"), defaultConfiguration);

    // Act
    Boolean result = filter.accept(newInputFile("autogenerated"));

    // Assert
    assertThat(result).isFalse();
    assertThat(logs.logs(LoggerLevel.DEBUG)).contains("Will ignore generated code");
    assertThat(logs.logs(LoggerLevel.DEBUG)).contains("Skipping auto generated file: autogenerated");
  }

  @Test
  public void accept_returns_true_for_nonautogenerated_files() throws IOException {
    // Arrange
    GeneratedFileFilter filter = createFilter(Paths.get("c:\\autogenerated").toUri(), defaultConfiguration);

    // Act
    Boolean result = filter.accept(newInputFile("File1"));

    // Assert
    assertThat(result).isTrue();
    assertThat(logs.logs(LoggerLevel.DEBUG)).contains("Will ignore generated code");
  }

  @Test
  public void accept_returns_true_for_autogenerated_files_when_analyzeGeneratedCode_setting_true() throws IOException {
    // Arrange
    AbstractSolutionConfiguration mockConfiguration = mock(AbstractSolutionConfiguration.class);
    when(mockConfiguration.analyzeGeneratedCode()).thenReturn(true);
    GeneratedFileFilter filter = createFilter(URI.create("autogenerated"), mockConfiguration);

    // Act
    Boolean result = filter.accept(newInputFile("autogenerated"));

    // Assert
    assertThat(result).isTrue();
    assertThat(logs.logs(LoggerLevel.DEBUG)).contains("Will analyze generated code");
  }

  private InputFile newInputFile(String uri) {
    InputFile file = mock(InputFile.class);
    when(file.uri()).thenReturn(URI.create(uri));
    when(file.toString()).thenReturn(uri);
    return file;
  }

  private GeneratedFileFilter createFilter(URI generated, AbstractSolutionConfiguration configuration) throws IOException {
    AbstractGlobalProtobufFileProcessor processor = mock(AbstractGlobalProtobufFileProcessor.class);
    when(processor.getGeneratedFileUris()).thenReturn(new HashSet<>(Arrays.asList(generated)));

    return new GeneratedFileFilter(processor, configuration);
  }
}
