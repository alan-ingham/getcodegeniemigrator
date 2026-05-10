using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using GetCodeGenie;

namespace GetCodeGenieMigrator
{
    public static class Migrator
    {
        // The JSON extension written alongside the original binary file.
        public const string JsonExtension = ".json";

        // Migrate a single .gcg2p file. Returns the path of the JSON file written.
        // Throws on any error so the caller can report it.
        public static string MigrateFile(string binaryPath)
        {
            State state = LoadBinary(binaryPath);
            StateDto dto = MapToDto(state);
            string jsonPath = binaryPath + JsonExtension;
            WriteJson(dto, jsonPath);
            return jsonPath;
        }

        // ── Load ────────────────────────────────────────────────────────────────

        private static State LoadBinary(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Binder = new GcgSerializationBinder();
                return (State)formatter.Deserialize(fs);
            }
        }

        // ── Map ─────────────────────────────────────────────────────────────────

        private static StateDto MapToDto(State s)
        {
            StateDto dto = new StateDto();

            dto.Colours = new List<int>();
            if (s.m_lColours != null)
                foreach (System.Drawing.Color c in s.m_lColours)
                    dto.Colours.Add(c.ToArgb());

            dto.SpecialWords = new List<SpecialWordDto>();
            if (s.m_lSpecialWords != null)
                foreach (SpecialWord sw in s.m_lSpecialWords)
                    dto.SpecialWords.Add(new SpecialWordDto { Word = sw.strWord, Checked = sw.bChecked });

            dto.Documents = new List<StateOneDocumentDto>();
            if (s.m_lList != null)
                foreach (StateOneDocument sod in s.m_lList)
                    dto.Documents.Add(MapDocument(sod));

            return dto;
        }

        private static StateOneDocumentDto MapDocument(StateOneDocument sod)
        {
            StateOneDocumentDto d = new StateOneDocumentDto
            {
                DocumentName      = sod.m_strDocumentName,
                DocumentTimestamp = sod.m_dtDocumentTimestamp,
                RichText          = sod.m_strRichText,
                Highlights        = new List<HighlightDto>(),
                Underlines        = new List<HighlightDto>(),
                Indices           = new List<IndexDto>()
            };

            if (sod.m_lHighlights != null)
                foreach (OneHighlight oh in sod.m_lHighlights)
                    d.Highlights.Add(new HighlightDto { Start = oh.Start, Length = oh.Length, ColourRect = oh.ColourRect });

            if (sod.m_lUnderlines != null)
                foreach (OneHighlight oh in sod.m_lUnderlines)
                    d.Underlines.Add(new HighlightDto { Start = oh.Start, Length = oh.Length, ColourRect = oh.ColourRect });

            if (sod.m_lIndices != null)
                foreach (OneParagraphIndex opi in sod.m_lIndices)
                    d.Indices.Add(new IndexDto { Start = opi.Start, Length = opi.Length, Indices = opi.Indices });

            return d;
        }

        // ── Write ────────────────────────────────────────────────────────────────

        private static void WriteJson(StateDto dto, string path)
        {
            string json = JsonConvert.SerializeObject(dto, Formatting.Indented);
            File.WriteAllText(path, json, System.Text.Encoding.UTF8);
        }
    }
}
