// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Auto-generated with Nuke.ToolGenerator.

using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

[assembly: IconClass(typeof(Nuke.Common.Tools.ReportGenerator.ReportGeneratorTasks), "flag3")]

namespace Nuke.Common.Tools.ReportGenerator
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ReportGeneratorTasks
    {
        static partial void PreProcess (ReportGeneratorSettings toolSettings);
        static partial void PostProcess (ReportGeneratorSettings toolSettings);
        /// <summary><p>ReportGenerator converts XML reports generated by OpenCover, PartCover, dotCover, Visual Studio, NCover or Cobertura into human readable reports in various formats.</p><p>The reports do not only show the coverage quota, but also include the source code and visualize which lines have been covered.</p><p>ReportGenerator supports merging several reports into one. It is also possible to pass one XML file containing several reports to ReportGenerator (e.g. a build log file).</p><p>The following <a href="https://github.com/danielpalme/ReportGenerator/wiki/Output-formats">output formats</a> are supported by ReportGenerator:<ul><li>HTML, HTMLSummary, HTMLInline, HTMLChart, <a href="https://en.wikipedia.org/wiki/MHTML">MHTML</a></li><li>XML, XMLSummary</li><li>Latex, LatexSummary</li><li>TextSummary</li><li>CsvSummary</li><li>PngChart</li><li>Badges</li><li><a href="https://github.com/danielpalme/ReportGenerator/wiki/Custom-reports">Custom reports</a></li></ul></p><p>Compatibility:<ul><li><a href="https://github.com/OpenCover/opencover">OpenCover</a></li><li><a href="https://github.com/sawilde/partcover.net4">PartCover 4.0</a></li><li><a href="http://sourceforge.net/projects/partcover">PartCover 2.2, 2.3</a></li><li><a href="https://www.jetbrains.com/dotcover/help/dotCover__Console_Runner_Commands.html">dotCover</a> (/ReportType=DetailedXML)</li><li>Visual Studio (<a href="https://github.com/danielpalme/ReportGenerator/wiki/Visual-Studio-Coverage-Tools#vstestconsoleexe">vstest.console.exe</a>, <a href="https://github.com/danielpalme/ReportGenerator/wiki/Visual-Studio-Coverage-Tools#codecoverageexe">CodeCoverage.exe</a>)</li><li><a href="http://www.ncover.com/download/current">NCover</a> (tested version 1.5.8, other versions may not work)</li><li><a href="https://github.com/cobertura/cobertura">Cobertura</a></li><li>Mono (<a href="http://www.mono-project.com/docs/debug+profile/profile/profiler/#analyzing-the-profile-data">mprof-report</a>)</li></ul></p><p>For more details, visit the <a href="https://github.com/danielpalme/ReportGenerator">official website</a>.</p></summary>
        public static void ReportGenerator (Configure<ReportGeneratorSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new ReportGeneratorSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
    }
    /// <summary><p>ReportGenerator converts XML reports generated by OpenCover, PartCover, dotCover, Visual Studio, NCover or Cobertura into human readable reports in various formats.</p><p>The reports do not only show the coverage quota, but also include the source code and visualize which lines have been covered.</p><p>ReportGenerator supports merging several reports into one. It is also possible to pass one XML file containing several reports to ReportGenerator (e.g. a build log file).</p><p>The following <a href="https://github.com/danielpalme/ReportGenerator/wiki/Output-formats">output formats</a> are supported by ReportGenerator:<ul><li>HTML, HTMLSummary, HTMLInline, HTMLChart, <a href="https://en.wikipedia.org/wiki/MHTML">MHTML</a></li><li>XML, XMLSummary</li><li>Latex, LatexSummary</li><li>TextSummary</li><li>CsvSummary</li><li>PngChart</li><li>Badges</li><li><a href="https://github.com/danielpalme/ReportGenerator/wiki/Custom-reports">Custom reports</a></li></ul></p><p>Compatibility:<ul><li><a href="https://github.com/OpenCover/opencover">OpenCover</a></li><li><a href="https://github.com/sawilde/partcover.net4">PartCover 4.0</a></li><li><a href="http://sourceforge.net/projects/partcover">PartCover 2.2, 2.3</a></li><li><a href="https://www.jetbrains.com/dotcover/help/dotCover__Console_Runner_Commands.html">dotCover</a> (/ReportType=DetailedXML)</li><li>Visual Studio (<a href="https://github.com/danielpalme/ReportGenerator/wiki/Visual-Studio-Coverage-Tools#vstestconsoleexe">vstest.console.exe</a>, <a href="https://github.com/danielpalme/ReportGenerator/wiki/Visual-Studio-Coverage-Tools#codecoverageexe">CodeCoverage.exe</a>)</li><li><a href="http://www.ncover.com/download/current">NCover</a> (tested version 1.5.8, other versions may not work)</li><li><a href="https://github.com/cobertura/cobertura">Cobertura</a></li><li>Mono (<a href="http://www.mono-project.com/docs/debug+profile/profile/profiler/#analyzing-the-profile-data">mprof-report</a>)</li></ul></p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ReportGeneratorSettings : ToolSettings
    {
        /// <summary>Path of the executable to be invoked.</summary>
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"ReportGenerator", packageExecutable: $"ReportGenerator.exe");
        /// <summary><p>The coverage reports that should be parsed (separated by semicolon). Wildcards are allowed.</p></summary>
        public virtual IReadOnlyList<string> Reports => ReportsInternal.AsReadOnly();
        internal List<string> ReportsInternal { get; set; } = new List<string>();
        /// <summary><p>The directory where the generated report should be saved.</p></summary>
        public virtual string TargetDirectory { get; internal set; }
        /// <summary><p>The output formats and scope (separated by semicolon). Default is Html.</p></summary>
        public virtual ReportTypes? ReportTypes { get; internal set; }
        /// <summary><p>Optional directories which contain the corresponding source code (separated by semicolon). The source files are used if coverage report contains classes without path information.</p></summary>
        public virtual IReadOnlyList<string> SourceDirectories => SourceDirectoriesInternal.AsReadOnly();
        internal List<string> SourceDirectoriesInternal { get; set; } = new List<string>();
        /// <summary><p>Optional directory for storing persistent coverage information. Can be used in future reports to show coverage evolution.</p></summary>
        public virtual string HistoryDirectory { get; internal set; }
        /// <summary><p>Optional list of assemblies that should be included or excluded in the report. Default is +*.</p></summary>
        public virtual IReadOnlyList<string> AssemblyFilters => AssemblyFiltersInternal.AsReadOnly();
        internal List<string> AssemblyFiltersInternal { get; set; } = new List<string>();
        /// <summary><p>Optional list of classes that should be included or excluded in the report. Exclusion filters take precedence over inclusion filters. Wildcards are allowed. Default is +*.</p></summary>
        public virtual IReadOnlyList<string> ClassFilters => ClassFiltersInternal.AsReadOnly();
        internal List<string> ClassFiltersInternal { get; set; } = new List<string>();
        /// <summary><p>The verbosity level of the log messages. Default is Verbose.</p></summary>
        public virtual ReportGeneratorVerbosity? Verbosity { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("-reports:{value}", Reports, mainSeparator: $";")
              .Add("-targetdir:{value}", TargetDirectory)
              .Add("-reporttypes:{value}", ReportTypes)
              .Add("-sourcedirs:{value}", SourceDirectories, mainSeparator: $";")
              .Add("-historydir:{value}", HistoryDirectory)
              .Add("-assemblyfilters:{value}", AssemblyFilters, mainSeparator: $" ")
              .Add("-classfilters:{value}", ClassFilters, mainSeparator: $" ")
              .Add("-verbosity:{value}", Verbosity);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ReportGeneratorSettingsExtensions
    {
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.Reports"/> to a new list.</em></p><p>The coverage reports that should be parsed (separated by semicolon). Wildcards are allowed.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetReports(this ReportGeneratorSettings toolSettings, params string[] reports)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportsInternal = reports.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.Reports"/> to a new list.</em></p><p>The coverage reports that should be parsed (separated by semicolon). Wildcards are allowed.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetReports(this ReportGeneratorSettings toolSettings, IEnumerable<string> reports)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportsInternal = reports.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a reports to the existing <see cref="ReportGeneratorSettings.Reports"/>.</em></p><p>The coverage reports that should be parsed (separated by semicolon). Wildcards are allowed.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddReports(this ReportGeneratorSettings toolSettings, params string[] reports)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportsInternal.AddRange(reports);
            return toolSettings;
        }
        /// <summary><p><em>Adds a reports to the existing <see cref="ReportGeneratorSettings.Reports"/>.</em></p><p>The coverage reports that should be parsed (separated by semicolon). Wildcards are allowed.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddReports(this ReportGeneratorSettings toolSettings, IEnumerable<string> reports)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportsInternal.AddRange(reports);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="ReportGeneratorSettings.Reports"/>.</em></p><p>The coverage reports that should be parsed (separated by semicolon). Wildcards are allowed.</p></summary>
        [Pure]
        public static ReportGeneratorSettings ClearReports(this ReportGeneratorSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single report to <see cref="ReportGeneratorSettings.Reports"/>.</em></p><p>The coverage reports that should be parsed (separated by semicolon). Wildcards are allowed.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddReport(this ReportGeneratorSettings toolSettings, string report, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (report != null || evenIfNull) toolSettings.ReportsInternal.Add(report);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single report from <see cref="ReportGeneratorSettings.Reports"/>.</em></p><p>The coverage reports that should be parsed (separated by semicolon). Wildcards are allowed.</p></summary>
        [Pure]
        public static ReportGeneratorSettings RemoveReport(this ReportGeneratorSettings toolSettings, string report)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportsInternal = toolSettings.Reports.Where(x => x == report).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.TargetDirectory"/>.</em></p><p>The directory where the generated report should be saved.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetTargetDirectory(this ReportGeneratorSettings toolSettings, string targetDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = targetDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.ReportTypes"/>.</em></p><p>The output formats and scope (separated by semicolon). Default is Html.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetReportTypes(this ReportGeneratorSettings toolSettings, ReportTypes? reportTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportTypes = reportTypes;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.SourceDirectories"/> to a new list.</em></p><p>Optional directories which contain the corresponding source code (separated by semicolon). The source files are used if coverage report contains classes without path information.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetSourceDirectories(this ReportGeneratorSettings toolSettings, params string[] sourceDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceDirectoriesInternal = sourceDirectories.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.SourceDirectories"/> to a new list.</em></p><p>Optional directories which contain the corresponding source code (separated by semicolon). The source files are used if coverage report contains classes without path information.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetSourceDirectories(this ReportGeneratorSettings toolSettings, IEnumerable<string> sourceDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceDirectoriesInternal = sourceDirectories.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a sourceDirectories to the existing <see cref="ReportGeneratorSettings.SourceDirectories"/>.</em></p><p>Optional directories which contain the corresponding source code (separated by semicolon). The source files are used if coverage report contains classes without path information.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddSourceDirectories(this ReportGeneratorSettings toolSettings, params string[] sourceDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceDirectoriesInternal.AddRange(sourceDirectories);
            return toolSettings;
        }
        /// <summary><p><em>Adds a sourceDirectories to the existing <see cref="ReportGeneratorSettings.SourceDirectories"/>.</em></p><p>Optional directories which contain the corresponding source code (separated by semicolon). The source files are used if coverage report contains classes without path information.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddSourceDirectories(this ReportGeneratorSettings toolSettings, IEnumerable<string> sourceDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceDirectoriesInternal.AddRange(sourceDirectories);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="ReportGeneratorSettings.SourceDirectories"/>.</em></p><p>Optional directories which contain the corresponding source code (separated by semicolon). The source files are used if coverage report contains classes without path information.</p></summary>
        [Pure]
        public static ReportGeneratorSettings ClearSourceDirectories(this ReportGeneratorSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceDirectoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single sourceDirectory to <see cref="ReportGeneratorSettings.SourceDirectories"/>.</em></p><p>Optional directories which contain the corresponding source code (separated by semicolon). The source files are used if coverage report contains classes without path information.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddSourceDirectory(this ReportGeneratorSettings toolSettings, string sourceDirectory, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (sourceDirectory != null || evenIfNull) toolSettings.SourceDirectoriesInternal.Add(sourceDirectory);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single sourceDirectory from <see cref="ReportGeneratorSettings.SourceDirectories"/>.</em></p><p>Optional directories which contain the corresponding source code (separated by semicolon). The source files are used if coverage report contains classes without path information.</p></summary>
        [Pure]
        public static ReportGeneratorSettings RemoveSourceDirectory(this ReportGeneratorSettings toolSettings, string sourceDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceDirectoriesInternal = toolSettings.SourceDirectories.Where(x => x == sourceDirectory).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.HistoryDirectory"/>.</em></p><p>Optional directory for storing persistent coverage information. Can be used in future reports to show coverage evolution.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetHistoryDirectory(this ReportGeneratorSettings toolSettings, string historyDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HistoryDirectory = historyDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.AssemblyFilters"/> to a new list.</em></p><p>Optional list of assemblies that should be included or excluded in the report. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetAssemblyFilters(this ReportGeneratorSettings toolSettings, params string[] assemblyFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyFiltersInternal = assemblyFilters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.AssemblyFilters"/> to a new list.</em></p><p>Optional list of assemblies that should be included or excluded in the report. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetAssemblyFilters(this ReportGeneratorSettings toolSettings, IEnumerable<string> assemblyFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyFiltersInternal = assemblyFilters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a assemblyFilters to the existing <see cref="ReportGeneratorSettings.AssemblyFilters"/>.</em></p><p>Optional list of assemblies that should be included or excluded in the report. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddAssemblyFilters(this ReportGeneratorSettings toolSettings, params string[] assemblyFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyFiltersInternal.AddRange(assemblyFilters);
            return toolSettings;
        }
        /// <summary><p><em>Adds a assemblyFilters to the existing <see cref="ReportGeneratorSettings.AssemblyFilters"/>.</em></p><p>Optional list of assemblies that should be included or excluded in the report. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddAssemblyFilters(this ReportGeneratorSettings toolSettings, IEnumerable<string> assemblyFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyFiltersInternal.AddRange(assemblyFilters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="ReportGeneratorSettings.AssemblyFilters"/>.</em></p><p>Optional list of assemblies that should be included or excluded in the report. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings ClearAssemblyFilters(this ReportGeneratorSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyFiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single assemblyFilter to <see cref="ReportGeneratorSettings.AssemblyFilters"/>.</em></p><p>Optional list of assemblies that should be included or excluded in the report. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddAssemblyFilter(this ReportGeneratorSettings toolSettings, string assemblyFilter, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (assemblyFilter != null || evenIfNull) toolSettings.AssemblyFiltersInternal.Add(assemblyFilter);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single assemblyFilter from <see cref="ReportGeneratorSettings.AssemblyFilters"/>.</em></p><p>Optional list of assemblies that should be included or excluded in the report. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings RemoveAssemblyFilter(this ReportGeneratorSettings toolSettings, string assemblyFilter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyFiltersInternal = toolSettings.AssemblyFilters.Where(x => x == assemblyFilter).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.ClassFilters"/> to a new list.</em></p><p>Optional list of classes that should be included or excluded in the report. Exclusion filters take precedence over inclusion filters. Wildcards are allowed. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetClassFilters(this ReportGeneratorSettings toolSettings, params string[] classFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassFiltersInternal = classFilters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.ClassFilters"/> to a new list.</em></p><p>Optional list of classes that should be included or excluded in the report. Exclusion filters take precedence over inclusion filters. Wildcards are allowed. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetClassFilters(this ReportGeneratorSettings toolSettings, IEnumerable<string> classFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassFiltersInternal = classFilters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a classFilters to the existing <see cref="ReportGeneratorSettings.ClassFilters"/>.</em></p><p>Optional list of classes that should be included or excluded in the report. Exclusion filters take precedence over inclusion filters. Wildcards are allowed. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddClassFilters(this ReportGeneratorSettings toolSettings, params string[] classFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassFiltersInternal.AddRange(classFilters);
            return toolSettings;
        }
        /// <summary><p><em>Adds a classFilters to the existing <see cref="ReportGeneratorSettings.ClassFilters"/>.</em></p><p>Optional list of classes that should be included or excluded in the report. Exclusion filters take precedence over inclusion filters. Wildcards are allowed. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddClassFilters(this ReportGeneratorSettings toolSettings, IEnumerable<string> classFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassFiltersInternal.AddRange(classFilters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="ReportGeneratorSettings.ClassFilters"/>.</em></p><p>Optional list of classes that should be included or excluded in the report. Exclusion filters take precedence over inclusion filters. Wildcards are allowed. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings ClearClassFilters(this ReportGeneratorSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassFiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single classFilter to <see cref="ReportGeneratorSettings.ClassFilters"/>.</em></p><p>Optional list of classes that should be included or excluded in the report. Exclusion filters take precedence over inclusion filters. Wildcards are allowed. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings AddClassFilter(this ReportGeneratorSettings toolSettings, string classFilter, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (classFilter != null || evenIfNull) toolSettings.ClassFiltersInternal.Add(classFilter);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single classFilter from <see cref="ReportGeneratorSettings.ClassFilters"/>.</em></p><p>Optional list of classes that should be included or excluded in the report. Exclusion filters take precedence over inclusion filters. Wildcards are allowed. Default is +*.</p></summary>
        [Pure]
        public static ReportGeneratorSettings RemoveClassFilter(this ReportGeneratorSettings toolSettings, string classFilter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassFiltersInternal = toolSettings.ClassFilters.Where(x => x == classFilter).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="ReportGeneratorSettings.Verbosity"/>.</em></p><p>The verbosity level of the log messages. Default is Verbose.</p></summary>
        [Pure]
        public static ReportGeneratorSettings SetVerbosity(this ReportGeneratorSettings toolSettings, ReportGeneratorVerbosity? verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
    }
    /// <summary><p>ReportGenerator converts XML reports generated by OpenCover, PartCover, dotCover, Visual Studio, NCover or Cobertura into human readable reports in various formats.</p><p>The reports do not only show the coverage quota, but also include the source code and visualize which lines have been covered.</p><p>ReportGenerator supports merging several reports into one. It is also possible to pass one XML file containing several reports to ReportGenerator (e.g. a build log file).</p><p>The following <a href="https://github.com/danielpalme/ReportGenerator/wiki/Output-formats">output formats</a> are supported by ReportGenerator:<ul><li>HTML, HTMLSummary, HTMLInline, HTMLChart, <a href="https://en.wikipedia.org/wiki/MHTML">MHTML</a></li><li>XML, XMLSummary</li><li>Latex, LatexSummary</li><li>TextSummary</li><li>CsvSummary</li><li>PngChart</li><li>Badges</li><li><a href="https://github.com/danielpalme/ReportGenerator/wiki/Custom-reports">Custom reports</a></li></ul></p><p>Compatibility:<ul><li><a href="https://github.com/OpenCover/opencover">OpenCover</a></li><li><a href="https://github.com/sawilde/partcover.net4">PartCover 4.0</a></li><li><a href="http://sourceforge.net/projects/partcover">PartCover 2.2, 2.3</a></li><li><a href="https://www.jetbrains.com/dotcover/help/dotCover__Console_Runner_Commands.html">dotCover</a> (/ReportType=DetailedXML)</li><li>Visual Studio (<a href="https://github.com/danielpalme/ReportGenerator/wiki/Visual-Studio-Coverage-Tools#vstestconsoleexe">vstest.console.exe</a>, <a href="https://github.com/danielpalme/ReportGenerator/wiki/Visual-Studio-Coverage-Tools#codecoverageexe">CodeCoverage.exe</a>)</li><li><a href="http://www.ncover.com/download/current">NCover</a> (tested version 1.5.8, other versions may not work)</li><li><a href="https://github.com/cobertura/cobertura">Cobertura</a></li><li>Mono (<a href="http://www.mono-project.com/docs/debug+profile/profile/profiler/#analyzing-the-profile-data">mprof-report</a>)</li></ul></p></summary>
    [PublicAPI]
    [Flags]
    public enum ReportTypes
    {
        Badges,
        CsvSummary,
        Html,
        HtmlInline,
        HtmlChart,
        HtmlSummary,
        Latex,
        LatexSummary,
        MHtml,
        PngChart,
        TextSummary,
        Xml,
        XmlSummary,
    }
    /// <summary><p>ReportGenerator converts XML reports generated by OpenCover, PartCover, dotCover, Visual Studio, NCover or Cobertura into human readable reports in various formats.</p><p>The reports do not only show the coverage quota, but also include the source code and visualize which lines have been covered.</p><p>ReportGenerator supports merging several reports into one. It is also possible to pass one XML file containing several reports to ReportGenerator (e.g. a build log file).</p><p>The following <a href="https://github.com/danielpalme/ReportGenerator/wiki/Output-formats">output formats</a> are supported by ReportGenerator:<ul><li>HTML, HTMLSummary, HTMLInline, HTMLChart, <a href="https://en.wikipedia.org/wiki/MHTML">MHTML</a></li><li>XML, XMLSummary</li><li>Latex, LatexSummary</li><li>TextSummary</li><li>CsvSummary</li><li>PngChart</li><li>Badges</li><li><a href="https://github.com/danielpalme/ReportGenerator/wiki/Custom-reports">Custom reports</a></li></ul></p><p>Compatibility:<ul><li><a href="https://github.com/OpenCover/opencover">OpenCover</a></li><li><a href="https://github.com/sawilde/partcover.net4">PartCover 4.0</a></li><li><a href="http://sourceforge.net/projects/partcover">PartCover 2.2, 2.3</a></li><li><a href="https://www.jetbrains.com/dotcover/help/dotCover__Console_Runner_Commands.html">dotCover</a> (/ReportType=DetailedXML)</li><li>Visual Studio (<a href="https://github.com/danielpalme/ReportGenerator/wiki/Visual-Studio-Coverage-Tools#vstestconsoleexe">vstest.console.exe</a>, <a href="https://github.com/danielpalme/ReportGenerator/wiki/Visual-Studio-Coverage-Tools#codecoverageexe">CodeCoverage.exe</a>)</li><li><a href="http://www.ncover.com/download/current">NCover</a> (tested version 1.5.8, other versions may not work)</li><li><a href="https://github.com/cobertura/cobertura">Cobertura</a></li><li>Mono (<a href="http://www.mono-project.com/docs/debug+profile/profile/profiler/#analyzing-the-profile-data">mprof-report</a>)</li></ul></p></summary>
    [PublicAPI]
    public enum ReportGeneratorVerbosity
    {
        Off,
        Verbose,
        Info,
        Warning,
        Error,
    }
}
