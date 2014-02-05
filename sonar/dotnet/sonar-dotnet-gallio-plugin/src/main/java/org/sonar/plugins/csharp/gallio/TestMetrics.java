/*
 * Sonar .NET Plugin :: Gallio
 * Copyright (C) 2010 Jose Chillan, Alexandre Victoor and SonarSource
 * dev@sonar.codehaus.org
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
 * You should have received a copy of the GNU Lesser General Public
 * License along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02
 */
package org.sonar.plugins.csharp.gallio;

import com.google.common.collect.ImmutableList;
import org.sonar.api.measures.AverageFormula;
import org.sonar.api.measures.CoreMetrics;
import org.sonar.api.measures.Metric;
import org.sonar.api.measures.Metrics;
import org.sonar.api.measures.SumChildValuesFormula;

import java.util.List;

/**
 * Test-related metrics that don't exist in Sonar Core for the moment.
 *
 * @author Fabrice Bellingard, June 22, 2011
 * @author Jose CHILLAN Apr 30, 2009
 */
public class TestMetrics implements Metrics {

  public static final Metric COUNT_ASSERTS = new Metric.Builder("count_asserts", "Asserts Counted", Metric.ValueType.INT)
    .setDescription("The average number of assertions performed by unit tests").setDirection(Metric.DIRECTION_BETTER).setQualitative(true)
    .setDomain(CoreMetrics.DOMAIN_TESTS).setFormula(new SumChildValuesFormula(true)).create();

  public static final Metric ASSERT_PER_TEST = new Metric.Builder("assert_per_test", "Asserts per Test", Metric.ValueType.FLOAT)
    .setDescription("The average number of asserts per test").setDirection(Metric.DIRECTION_BETTER).setQualitative(true)
    .setDomain(CoreMetrics.DOMAIN_TESTS).setFormula(AverageFormula.create(TestMetrics.COUNT_ASSERTS, CoreMetrics.TESTS)).create();

  public static final Metric ELOC = new Metric.Builder("eloc", "Effective lines of code", Metric.ValueType.INT)
    .setDescription("The number of lines of code with statements").setDirection(Metric.DIRECTION_WORST).setQualitative(false)
    .setDomain(CoreMetrics.DOMAIN_SIZE).setFormula(new SumChildValuesFormula(true)).create();

  @Override
  public List<Metric> getMetrics() {
    return ImmutableList.of(
      COUNT_ASSERTS,
      ELOC,
      ASSERT_PER_TEST);
  }

}
