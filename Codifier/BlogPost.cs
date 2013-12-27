using System;
using System.IO;
using System.Text;

using MarkdownDeep;

namespace Codifier
{
    public static class BlogPost
    {
        public static string GenerateHtml(string syntax)
        {
            var markdown = new Markdown();
            markdown.FormatCodeBlock = (m, s) => FormatCodeBlock(s);
            return markdown.Transform(syntax);
        }

        private static string FormatCodeBlock(string text)
        {
            var sb = new StringBuilder();

            using (var stringReader = new StringReader(text))
            {
                sb.Append("<pre><code>");

                var isFirstLine = true;

                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                    }
                    else
                    {
                        sb.Append("<br>");
                    }

                    var startOfLine = true;

                    foreach (var c in line)
                    {
                        if (startOfLine & Char.IsWhiteSpace(c))
                        {
                            sb.Append("&nbsp;");
                        }
                        else
                        {
                            startOfLine = false;
                            sb.Append(c);
                        }
                    }

                }

                sb.AppendLine("</code></pre>");
            }

            return sb.ToString();
        }
    }
}