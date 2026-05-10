using System;
using System.Collections.Generic;

// Plain data-transfer objects used for JSON output.
// No BinaryFormatter concerns here — clean types that System.Text.Json
// (on the .NET 10 side) can deserialize without any special handling.

namespace GetCodeGenieMigrator
{
    public class StateDto
    {
        public List<StateOneDocumentDto> Documents    { get; set; }
        public List<SpecialWordDto>      SpecialWords { get; set; }
        public List<int>                 Colours      { get; set; } // Stored as ARGB int
    }

    public class StateOneDocumentDto
    {
        public string            DocumentName      { get; set; }
        public DateTime          DocumentTimestamp { get; set; }
        public string            RichText          { get; set; }
        public List<HighlightDto> Highlights       { get; set; }
        public List<HighlightDto> Underlines       { get; set; }
        public List<IndexDto>     Indices          { get; set; }
    }

    public class HighlightDto
    {
        public int Start      { get; set; }
        public int Length     { get; set; }
        public int ColourRect { get; set; }
    }

    public class IndexDto
    {
        public int    Start   { get; set; }
        public int    Length  { get; set; }
        public string Indices { get; set; }
    }

    public class SpecialWordDto
    {
        public string Word    { get; set; }
        public bool   Checked { get; set; }
    }
}
