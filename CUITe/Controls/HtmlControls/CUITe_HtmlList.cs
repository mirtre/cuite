﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CUITe.Controls.HtmlControls
{
    public class CUITe_HtmlList : CUITe_HtmlControl<HtmlList>
    {
        public CUITe_HtmlList() : base() { }
        public CUITe_HtmlList(string sSearchParameters) : base(sSearchParameters) { }

        /// <summary>
        /// Gets the items in a string array of the html list.
        /// </summary>
        public string[] Items
        {
            get
            {
                return GetPropertyOfChildren<string>(HtmlControl.PropertyNames.InnerText);
            }
        }
    }
}
