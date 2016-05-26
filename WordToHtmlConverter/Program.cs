﻿using System;
using System.Xml;
using System.Xml.Linq;

using OpenXmlPowerTools;

namespace WordToHtmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Error.WriteLine("Usage: WordToHtmlConverter.exe <input filename> <output filename>");
                Environment.Exit(1);
            }

            WmlToHtmlConverterSettings settings = new WmlToHtmlConverterSettings();
            XElement e = WmlToHtmlConverter.ConvertToHtml(new WmlDocument(args[0]), settings);

            XmlWriterSettings s = new XmlWriterSettings();
            s.OmitXmlDeclaration = true;
            s.Encoding = new System.Text.UTF8Encoding(false);
            XmlWriter writer = XmlWriter.Create(args[1], s);
            e.Element(Xhtml.body).WriteTo(writer);
            writer.Close();
        }
    }
}
