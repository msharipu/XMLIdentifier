using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            string test7 = "<Design><Code><People>Hello World</People></Code></Design>";
            string test8 = "<Design>test<Code>hello world</Code><XCode>hello world</XCode><YCode>hello world</YCode></Design>";
            string test9 = "<Design>test<Code>hello world</Design>";


            //Console.WriteLine(p.DetermineSxml(test1)); //output Pass
            //Console.WriteLine(p.DetermineSxml(test2)); //output Fail
            //Console.WriteLine(p.DetermineSxml(test3)); //output Fail
            //Console.WriteLine(p.DetermineSxml(test4)); //output Pass
            //Console.WriteLine(p.DetermineSxml(test5)); //output Pass
            //Console.WriteLine(p.DetermineSxml(test6)); //output Pass
            //Console.WriteLine(p.DetermineSxml(test7)); //output Pass
            //Console.WriteLine(p.DetermineSxml(test8)); //output Pass
            Console.WriteLine(p.DetermineSxml(test9)); //output Pass
            Console.ReadKey();
        }

        #region commented out code

        //bool DetermineSxml(string sxml)
        //{
        //    List<string> startElement = new List<string>();
        //    List<string> endElement = new List<string>();
        //    bool invalidXmlDetected = false;

        //    for (int i = 0; i < sxml.Length; i++)
        //    {
        //        if (invalidXmlDetected)
        //            break;

        //        int opIndex = 0;
        //        int edIndex = 0;

        //        if (sxml[i] == '<')
        //        {
        //            if ((sxml[i + 1]) != '/') // this is an opening element
        //            {
        //                opIndex = i + 1;
        //                edIndex = getLength(opIndex, sxml, ref invalidXmlDetected);

        //                if (edIndex == 0) // does not found any closing bracket, invalid
        //                    invalidXmlDetected = true;
        //                else
        //                {
        //                    startElement.Add(sxml.Substring(opIndex, edIndex));
        //                }
        //            }
        //            else // this is the closing element
        //            {
        //                opIndex = i + 2;
        //                edIndex = getLength(opIndex, sxml, ref invalidXmlDetected);
        //                if (edIndex == 0) // does not found any closing bracket, invalid
        //                    invalidXmlDetected = true;
        //                else
        //                {
        //                    endElement.Add(sxml.Substring(opIndex, edIndex));
        //                }

        //            }
        //        }
        //    }

        //    if (invalidXmlDetected)
        //        return false;
        //    else if (startElement.Count == 0 || endElement.Count == 0 || startElement.Count != endElement.Count) //every open element need to have closing, if count mismatch then return false
        //        return false;

        //    for (int i = 0; i < startElement.Count; i++)
        //    {
        //        if (startElement[i] != endElement[startElement.Count - (i +1) ]) // position of the start element and end element need to match. 
        //        {
        //            invalidXmlDetected = true;
        //            break;
        //        }

        //    }

        //    if (invalidXmlDetected)
        //        return false;

        //    return true;
        //}
        #endregion
        bool DetermineSxml(string sxml)
        {
            try
            {
                //Console.WriteLine("START");

                Console.WriteLine(sxml);

                string rootElementName = "";
                List<string> startElement = new List<string>();
                List<string> endElement = new List<string>();
                //bool invalidXmlDetected = false;

                for (int i = 0; i < sxml.Length; i++)
                {
                    //if (invalidXmlDetected)
                    //    break;

                    int opIndex = 0;
                    int edIndex = 0;

                    if (sxml[i] == '<')
                    {
                        if ((sxml[i + 1]) != '/') // this is an opening element
                        {
                            opIndex = i + 1;
                            edIndex = getLength(opIndex, sxml);

                            if (edIndex == 0) // does not found any closing bracket, invalid
                                throw new Exception("Invalid xml string, no closing tag found!");
                            //invalidXmlDetected = true;
                            else if (rootElementName == "") // this is the first element
                            {
                                rootElementName = sxml.Substring(opIndex, edIndex);
                                string bodyXml = sxml.Substring(edIndex + 2, FindEndRootElement(rootElementName, sxml,true));
                                //recursiveElementValidation(bodyXml);
                                recursiveElementValidation2(bodyXml);
                                //Console.WriteLine(bodyXml);
                                break;
                            }
                        }
                    }
                    break;
                }

                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return false;
            }
            //finally
            //{
            //    Console.WriteLine("END\n");
            //}

            
        }

        //private int FindEndRootElement(string rootElementName, string sxml, bool isRoot)
        //{
        //    string endRootElement = "</" + rootElementName + ">";
        //    int endRootIndex = 0;

        //    if (sxml.Contains(endRootElement))
        //    {
        //        endRootIndex = sxml.IndexOf(endRootElement);
        //        if (isRoot && (sxml.Substring(endRootIndex).IndexOf(">") + endRootIndex) + 1 < sxml.Length) //the root node should be the end, if there is value outside of '>' then consider as invalid node
        //            throw new Exception("Invalid root tag!");

        //        return endRootIndex - (endRootElement.Length - 1);

        //        //return endRootIndex;
        //    }

        //    return 0;
        //    //Console.WriteLine(sxml.Substring(endRootIndex -1 ));

        //}


        //private void recursiveElementValidation(string bodyXml)
        //{
        //    //if (!bodyXml.Contains("<"))
        //        //return;

        //    for (int i = 0; i < bodyXml.Length; i++)
        //    {
        //        int opIndex = 0;
        //        int edIndex = 0;

        //        if (bodyXml[i] == '<')
        //        {
        //            if ((bodyXml[i + 1]) != '/') // this is an opening element
        //            {
        //                opIndex = i + 1;
        //                edIndex = getLength(opIndex, bodyXml);

        //                if (edIndex == 0) // does not found any closing bracket, invalid
        //                    throw new Exception("Invalid xml string, no closing tag found!");
        //                else // this is the first element
        //                {
        //                    string ElementName = bodyXml.Substring(opIndex, edIndex);
        //                    Console.WriteLine(ElementName);
        //                    int lastElementIndex = FindEndRootElement(ElementName, bodyXml, false);
        //                    string body = bodyXml.Substring(edIndex + 2, lastElementIndex);
        //                    if (!body.Contains("<"))
        //                    {
        //                        i= opIndex + lastElementIndex;
        //                        continue;
        //                    }
        //                    else if (!body.StartsWith("<"))
        //                    {
        //                        body = bodyXml.Substring(body.IndexOf($"<{ElementName}>"), lastElementIndex);
        //                    }
        //                    //Console.WriteLine(body);
        //                    recursiveElementValidation(body);
        //                    //break;
        //                }
        //            }
        //        }
        //        //break;
        //    }
        
        //}

        private void recursiveElementValidation2(string bodyXml)
        {
            if (bodyXml.Contains("<") && !bodyXml.Contains(">"))
                throw new Exception("There is no closing element");
            else if (bodyXml.StartsWith("<") && !bodyXml.Substring(1).Equals("//"))
            {
                string elName = bodyXml.Substring(1, getLength(1, bodyXml));
                string closingElName = $"</{elName}>";

                if (bodyXml.Contains(closingElName))
                {
                    int lastElementIndex = FindEndRootElement(elName, bodyXml);
                    int startIndex = findElementClosingTag(bodyXml);
                    string body = bodyXml.Substring(startIndex + 1, lastElementIndex); //body might be Element value, or nested elements
                    recursiveElementValidation2(body); //if element value contains nested element, recursive will keep going until it does not find an element

                    if (lastElementIndex < bodyXml.Length) // if value less, means there is still more content to parse 
                    {
                        string output = bodyXml.Remove(0, (lastElementIndex + closingElName.Length + startIndex + 1));
                        recursiveElementValidation2(output);
                    }

                }
            }
            else if (bodyXml.Contains("<")) //possibly the body still has element but the start is the element value instead like test 8
            {
                int startIndexElement = bodyXml.IndexOf('<') + 1;
                string elName = bodyXml.Substring(startIndexElement, getLength(startIndexElement, bodyXml));
                string closingElName = $"</{elName}>";

                if (bodyXml.Contains(closingElName))
                {
                    int lastElementIndex = FindEndRootElement(elName, bodyXml) - (startIndexElement - 1);
                    int startIndex = findElementClosingTag(bodyXml);
                    string body = bodyXml.Substring(startIndex + 1, lastElementIndex); //body might be Element value, or nested elements
                    recursiveElementValidation2(body); //if element value contains nested element, recursive will keep going until it does not find an element

                    if (lastElementIndex < bodyXml.Length) // if value less, means there is still more content to parse 
                    {
                        string output = bodyXml.Remove(0, (lastElementIndex + closingElName.Length + startIndex + 1));
                        recursiveElementValidation2(output);
                    }

                }
                Console.WriteLine("yahoo\t" + bodyXml);
            }
        }

        /// <summary>
        /// Find first matching index of '>'
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int findElementClosingTag(string input)
        {
            for (int x = 0; x < input.Length; x++)
                if (input[x] == '>')
                    return x;

            return 0;
        }


        /// <summary>
        /// Return the index of the closing element based on the XML input
        /// Ex: <End>Value<\/End>, return 'e' index
        /// </summary>
        /// <param name="rootElementName"></param>
        /// <param name="sxml"></param>
        /// <param name="isRoot"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private int FindEndRootElement(string rootElementName, string sxml, bool isRoot = false)
        {
            string endRootElement = "</" + rootElementName+">";
            int endRootIndex = 0;

            if (sxml.Contains(endRootElement))
            {
                endRootIndex = sxml.IndexOf(endRootElement);
                if (isRoot && (sxml.Substring(endRootIndex).IndexOf(">") + endRootIndex) + 1 < sxml.Length) //the root node should be the end, if there is value outside of '>' then consider as invalid node
                    throw new Exception("Invalid root tag!");

                return endRootIndex - (endRootElement.Length - 1);

                //return endRootIndex;
            }

            return 0;
            //Console.WriteLine(sxml.Substring(endRootIndex -1 ));
            
        }

        
        /// <summary>
        /// Returned the lenght of the element name
        /// Ex: <Name> return 'Name'
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="sxml"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        int getLength(int startIndex, string sxml)
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
                    //invalidXmlDetected = true;
                    throw new Exception("Invalid xml string, found another opening bracker!");
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
