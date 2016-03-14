//-----------------------------------------------------------------------
//
// <copyright file="ExcelWriter.cs" company="Omni-ID, Ltd.">
//
// Copyright (c) 2013, 2014 - Omni-ID, Ltd. All rights reserved.
//
// <author>Omni-ID</author>
//
// </copyright>
//
//-----------------------------------------------------------------------



using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.CustomProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace CheckSumVerifier
{
    public class XlsxReader
    {
        #region Export To Excel 2007 [xlsx format]

        /// <summary>
        /// Gets the check sum from file property.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static string GetCheckSumFromFileProperty(string filePath)
        {
            string checkSum = string.Empty;
            using (var wb = SpreadsheetDocument.Open(filePath, false))
            {
                // "Finding existing properties...
                var customPropsPart = wb.CustomFilePropertiesPart;
                if (customPropsPart != null)
                {

                    var props = customPropsPart.Properties;
                    if (props != null)
                    {
                        foreach (var prop in props.Where(
                            prop => ((CustomDocumentProperty)prop).Name.Value == "ChecksumKey"))
                        {
                            //"get the value"
                            checkSum = prop.InnerText;
                            //  prop.Remove();
                        }
                    }
                }
              
            }

            return checkSum;
        }

        /// <summary>
        /// Gets the stream spreadsheet workbook.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static string GetCheckSumFromFile(string filePath)
        {
            using (var wb = SpreadsheetDocument.Open(filePath, false))
            {
                string checksum = CheckSumAlgorithms.GetChecksum(wb.WorkbookPart.GetStream(), "MD5");

                return  CheckSumAlgorithms.GetChecksumFromString(checksum, "MD5");

            }
            
        }

      
        #endregion
    }

   
}
