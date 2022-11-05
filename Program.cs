using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLIdentifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string test1 = "<Design><Code>hello world</Code></Design>";
            string test2 = "<Design><Code>hello world</Code></Design><People>";
            string test3 = "<People><Design><Code>hello world</People></Code></Design>";
            string test4 = "<Design><Code>hello world</Code><Code>hello world</Code><Code>hello world</Code></Design>";
            string test5 = "<Design><Code>hello world</Code><Code>hello world</Code><Code>hello world</Code><Test><SubTest>1</SubTest><SubTest>2</SubTest><SubTest>3</SubTest><SubTest>4</SubTest></Test></Design>";
            string test6 = "<Design><Code>hello world</Code><XCode>hello world</XCode><YCode>hello world</YCode></Design>";


            Console.WriteLine(p.DetermineSxml(test1));
            Console.WriteLine(p.DetermineSxml(test2));
            Console.WriteLine(p.DetermineSxml(test3));
            Console.WriteLine(p.DetermineSxml(test4));
            Console.WriteLine(p.DetermineSxml(test5)); //failed need to fix, its a valid xml
            Console.WriteLine(p.DetermineSxml(test6)); //failed need to fix, its a valid xml
            Console.ReadKey();
        }

        bool DetermineSxml(string sxml)
        {
            List<string> startElement = new List<string>();
            List<string> endElement = new List<string>();
            bool invalidXmlDetected = false;

            for (int i = 0; i < sxml.Length; i++)
            {
                if (invalidXmlDetected)
                    break;

                int opIndex = 0;
                int edIndex = 0;

                if (sxml[i] == '<')
                {
                    if ((sxml[i + 1]) != '/') // this is an opening element
                    {
                        opIndex = i + 1;
                        edIndex = getLength(opIndex, sxml, ref invalidXmlDetected);
                       
                        if (edIndex == 0) // does not found any closing bracket, invalid
                            invalidXmlDetected = true;
                        else
                        {
                            startElement.Add(sxml.Substring(opIndex, edIndex));
                        }
                    }
                    else // this is the closing element
                    {
                        opIndex = i + 2;
                        edIndex = getLength(opIndex, sxml, ref invalidXmlDetected);
                        if (edIndex == 0) // does not found any closing bracket, invalid
                            invalidXmlDetected = true;
                        else
                        {
                            endElement.Add(sxml.Substring(opIndex, edIndex));
                        }

                    }
                }
            }

            if (invalidXmlDetected)
                return false;
            else if (startElement.Count == 0 || endElement.Count == 0 || startElement.Count != endElement.Count) //every open element need to have closing, if count mismatch then return false
                return false;

            for (int i = 0; i < startElement.Count; i++)
            {
                if (startElement[i] != endElement[startElement.Count - (i +1) ]) // position of the start element and end element need to match. 
                {
                    invalidXmlDetected = true;
                    break;
                }

            }

            if (invalidXmlDetected)
                return false;

            return true;
        }

        int getLength(int startIndex, string sxml, ref bool invalidXmlDetected)
        {
            int length = 0;
            int edIndex = 0;

            for (int j = startIndex; j < sxml.Length; j++)
            {
                length++;
                if (sxml[j] != '>')
                    continue;
                else if (sxml[j] == '<') // if found another opening bracket, then this is an invalid
                {
                    invalidXmlDetected = true;
                    break;
                }
                else // found '>', get the index
                {
                    edIndex = length - 1;
                    break;
                }
            }

            return edIndex;
        }
    }
}
