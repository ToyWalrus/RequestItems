﻿using System;
using UnityEngine;
using Verse;

namespace ItemRequests
{
    // This class was adapted from the class PanelBase
    // from the mod EdB Prepare Carefully by edbmods
    // https://github.com/edbmods/EdBPrepareCarefully/blob/develop/Source/PanelBase.cs
    public class Panel
    {
        public Rect HeaderLabelRect
        {
            get;
            private set;
        }
        public Rect PanelRect
        {
            get;
            protected set;
        }
        public Rect BodyRect
        {
            get;
            protected set;
        }
        public virtual string PanelHeader
        {
            get
            {
                return null;
            }
        }
        public string Warning
        {
            get;
            set;
        }
        public Panel()
        {
        }

        public virtual void Resize(Rect rect)
        {
            PanelRect = rect;
            BodyRect = new Rect(0, 0, rect.width, rect.height);
            if (PanelHeader != null)
            {
                BodyRect = new Rect(0, 36, rect.width, rect.height - 36);
            }
        }
        public virtual void Draw()
        {
            DrawPanelBackground();
            DrawPanelHeader();
            GUI.BeginGroup(PanelRect);
            try
            {
                DrawPanelContent();
            }
            finally
            {
                GUI.EndGroup();
            }
            GUI.color = Color.white;
        }
        protected virtual void DrawPanelBackground()
        {
            GUI.color = Style.ColorPanelBackground;
            GUI.DrawTexture(PanelRect, BaseContent.WhiteTex);
            GUI.color = Color.white;
        }
        protected virtual void DrawPanelHeader()
        {
            if (PanelHeader == null)
            {
                return;
            }
            HeaderLabelRect = new Rect(10 + PanelRect.xMin, 3 + PanelRect.yMin, PanelRect.width - 30, 40);
            var fontValue = Text.Font;
            var anchorValue = Text.Anchor;
            var colorValue = GUI.color;
            Text.Font = GameFont.Medium;
            Text.Anchor = TextAnchor.UpperLeft;
            Widgets.Label(HeaderLabelRect, PanelHeader);
            Text.Font = fontValue;
            Text.Anchor = anchorValue;
            GUI.color = colorValue;
        }
        protected virtual void DrawPanelContent()
        {
            GUI.color = Style.ColorTextPanelHeader;

            GUI.color = Color.white;
        }
    }
}
