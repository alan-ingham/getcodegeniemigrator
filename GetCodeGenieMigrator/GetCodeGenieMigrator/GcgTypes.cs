using System;
using System.Collections.Generic;
using System.Drawing;

// These are stripped-down copies of the serializable classes from GetCodeGenie.
// They must live in the GetCodeGenie namespace and use exactly the same field names
// as the originals, because BinaryFormatter bakes both into the .gcg2p file.
// All WinForms/RichTextBox methods have been removed — we only need the data.

namespace GetCodeGenie
{
    [Serializable]
    public class State
    {
        public List<StateOneDocument> m_lList;
        public List<SpecialWord>      m_lSpecialWords;
        public List<Color>            m_lColours;
    }

    [Serializable]
    public class StateOneDocument : IComparable<StateOneDocument>
    {
        public String               m_strDocumentName;
        public DateTime             m_dtDocumentTimestamp;
        public String               m_strRichText;
        public List<OneHighlight>   m_lHighlights;
        public List<OneHighlight>   m_lUnderlines;
        public List<OneParagraphIndex> m_lIndices;

        public int CompareTo(StateOneDocument other)
        {
            return m_strDocumentName.CompareTo(other.m_strDocumentName);
        }
    }

    [Serializable]
    public class OneHighlight
    {
        private int m_nStart;
        private int m_nLength;
        private int m_nColourRectangle;

        public int Start       { get { return m_nStart; }            set { m_nStart = value; } }
        public int Length      { get { return m_nLength; }           set { m_nLength = value; } }
        public int ColourRect  { get { return m_nColourRectangle; }  set { m_nColourRectangle = value; } }
    }

    [Serializable]
    public class OneParagraphIndex
    {
        private int    m_nStart;
        private int    m_nLength;
        private String m_strIndices;

        public int    Start   { get { return m_nStart; }    set { m_nStart = value; } }
        public int    Length  { get { return m_nLength; }   set { m_nLength = value; } }
        public String Indices { get { return m_strIndices; } set { m_strIndices = value; } }
    }

    [Serializable]
    public class SpecialWord
    {
        public String  strWord;
        public Boolean bChecked;
    }
}
