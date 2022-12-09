using AntDesign.Charts;

namespace Blazor_QLSV04.Pages
{
    internal class GroupedColumnConfig
    {
        public Title Title { get; internal set; }
        public bool ForceFit { get; internal set; }
        public string XField { get; internal set; }
        public ColumnViewConfigLabel Label { get; internal set; }
        public string YField { get; internal set; }
        public ValueAxis YAxis { get; internal set; }
        public string GroupField { get; internal set; }
        public string[] Color { get; internal set; }
    }
}