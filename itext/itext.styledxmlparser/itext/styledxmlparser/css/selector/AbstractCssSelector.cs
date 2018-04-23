/*
This file is part of the iText (R) project.
Copyright (c) 1998-2018 iText Group NV
Authors: Bruno Lowagie, Paulo Soares, et al.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
using System;
using System.Collections.Generic;
using System.Text;
using iText.IO.Util;
using iText.StyledXmlParser.Css.Selector.Item;
using iText.StyledXmlParser.Node;

namespace iText.StyledXmlParser.Css.Selector {
    /// <summary>Abstract superclass for CSS Selectors.</summary>
    public abstract class AbstractCssSelector : ICssSelector {
        /// <summary>The selector items.</summary>
        internal IList<ICssSelectorItem> selectorItems;

        /// <summary>
        /// Creates a new
        /// <see cref="AbstractCssSelector"/>
        /// instance.
        /// </summary>
        /// <param name="selectorItems">the selector items</param>
        public AbstractCssSelector(IList<ICssSelectorItem> selectorItems) {
            this.selectorItems = selectorItems;
        }

        public virtual IList<ICssSelectorItem> GetSelectorItems() {
            return JavaCollectionsUtil.UnmodifiableList(selectorItems);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.html2pdf.css.selector.ICssSelector#calculateSpecificity()
        */
        public virtual int CalculateSpecificity() {
            int specificity = 0;
            foreach (ICssSelectorItem item in selectorItems) {
                specificity += item.GetSpecificity();
            }
            return specificity;
        }

        /* (non-Javadoc)
        * @see java.lang.Object#toString()
        */
        public override String ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (ICssSelectorItem item in selectorItems) {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }

        public abstract bool Matches(INode arg1);
    }
}
