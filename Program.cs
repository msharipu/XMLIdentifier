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
            string test10 = "<Design><Code>hello world</Design>";
            string test11 = "<Design>test<Code attr=\"123\">hello world</Code><XCode>hello world</XCode><YCode attr=\"123\">hello world</YCode></Design>";
            string test12 = "<Design><Code attr=\"123\">hello world</Code><XCode>hello world</XCode><YCode attr=\"123\">hello world</YCode></Design>";
            string test13 = "<Design><Code><People>Hello World</code></Design>";
            string test14 = "<Design><Code>hello world</Code><Code>hello world</Code><Code attr=\"xxx\">hello world</Code><Test><SubTest attr=\"1\">1</SubTest><SubTest>2</SubTest><SubTest>3</SubTest><SubTest>4</SubTest></Test></Design>";
            string test15 = "<Design><Test><SubTest>1</SubTest><SubTest>2</SubTest><SubTest>3</SubTest><SubTest>4</SubTest></Test><Code>hello world</Code><Code>hello world</Code><Code>hello world</Code></Design>";
            string test16 = "<Design><Test /></Design>";
            string test17 = "<Design><Test /><Test1></Test1></Design>";
            string test18 = "<Design>123<Test /><Test1></Test1></Design>";
            string test19 = "<Design>123<Test /><Test1></Test1><Test2/></Design>";


            //Console.WriteLine(p.DetermineSxml(test1)); //output True
            //Console.WriteLine(p.DetermineSxml(test2)); //output False
            //Console.WriteLine(p.DetermineSxml(test3)); //output False
            //Console.WriteLine(p.DetermineSxml(test4)); //output True
            //Console.WriteLine(p.DetermineSxml(test5)); //output True
            //Console.WriteLine(p.DetermineSxml(test6)); //output True
            //Console.WriteLine(p.DetermineSxml(test7)); //output True
            //Console.WriteLine(p.DetermineSxml(test8)); //output True
            //Console.WriteLine(p.DetermineSxml(test9)); //output False
            //Console.WriteLine(p.DetermineSxml(test10)); //output False
            //Console.WriteLine(p.DetermineSxml(test11)); //output True
            //Console.WriteLine(p.DetermineSxml(test12)); //output True
            //Console.WriteLine(p.DetermineSxml(test13)); //output False
            //Console.WriteLine(p.DetermineSxml(test14)); //output True
            //Console.WriteLine(p.DetermineSxml(test15)); //output True
            //Console.WriteLine(p.DetermineSxml(test16)); //output True
            //Console.WriteLine(p.DetermineSxml(test17)); //output True
            //Console.WriteLine(p.DetermineSxml(test18)); //output True
            Console.WriteLine(p.DetermineSxml(test19)); //output True
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
        //bool DetermineSxml(string sxml)
        //{
        //    try
        //    {
        //        //Console.WriteLine("START");
        //        //Console.WriteLine(sxml);

        //        string rootElementName = "";
        //        List<string> startElement = new List<string>();
        //        List<string> endElement = new List<string>();
                
        //        for (int i = 0; i < sxml.Length; i++)
        //        {

        //            int opIndex = 0;
        //            int edIndex = 0;

        //            if (sxml[i] == '<')
        //            {
        //                if ((sxml[i + 1]) != '/') // this is an opening element
        //                {
        //                    opIndex = i + 1;
        //                    edIndex = getLength(opIndex, sxml);

        //                    if (edIndex == 0) // does not found any closing bracket, invalid
        //                        throw new Exception("Invalid xml string, no closing tag found!");
        //                    //invalidXmlDetected = true;
        //                    else if (rootElementName == "") // this is the first element
        //                    {
        //                        rootElementName = sxml.Substring(opIndex, edIndex);
        //                        string bodyXml = sxml.Substring(edIndex + 2, FindEndRootElement(rootElementName, sxml,true));
        //                        //recursiveElementValidation(bodyXml);
        //                        recursiveElementValidation2(bodyXml);
        //                        //Console.WriteLine(bodyXml);
        //                        break;
        //                    }
        //                }
        //            }
        //            break;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //}

        bool DetermineSxml(string sxml)
        {
            try
            {
                //Console.WriteLine("START");
                //Console.WriteLine(sxml);

                recursiveElementValidation2(sxml);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void recursiveElementValidation2(string bodyXml)
        {
            Console.WriteLine(bodyXml);

            if (bodyXml.Contains("<") && !bodyXml.Contains(">"))
                throw new Exception("There is no closing element");
            else if (bodyXml.StartsWith("<") && !bodyXml.Substring(1).Equals("//"))
            {
                bool elHasAttribute = false;
                List<string> attributes = new List<string>();
                string elName = bodyXml.Substring(1, getLength(1, bodyXml));
                if (elName.Contains(" "))
                {
                    attributes.AddRange(elName.Split(' '));
                    //if (attributes.Count == 1)
                    //    throw new Exception("Invalid Xml input string, Element name cannot have spaces!");
                    elName = attributes[0];
                    elHasAttribute = true;
                }

                string closingElName = $"</{elName}>";
                string closingSelfElName = elName.EndsWith("/") ? $"<{elName}>" : $"<{elName}/>";

                if (bodyXml.Contains(closingElName)) //element name are case sensitive
                {
                    int attributeLength = 0;
                    if (elHasAttribute)
                    {
                        for (int i = 1; i < attributes.Count; i++)
                            attributeLength = attributes[i].Length + 1; //+1 to include space 

                    }

                    int lastElementIndex = FindEndRootElement(elName, bodyXml);
                    int startIndex = findElementClosingTag(bodyXml);
                    string body = bodyXml.Substring(startIndex + 1, lastElementIndex - attributeLength); //body might be Element value, or nested elements
                    if(body.Length > 0)
                        recursiveElementValidation2(body); //if element value contains nested element, recursive will keep going until it does not find an element

                    if (lastElementIndex < bodyXml.Length) // if value less, means there is still more content to parse 
                    {
                        int lengthToRemove = (lastElementIndex - attributeLength) + closingElName.Length + startIndex + 1;
                        string output = bodyXml.Remove(0, lengthToRemove);
                        if (output.Length > 0)
                            recursiveElementValidation2(output);
                    }

                }
                else if (String.Concat(bodyXml.Where(c => !Char.IsWhiteSpace(c))).Contains(closingSelfElName)) //cater the scenario where an element self close
                {
                    int lastElementIndex = findElementClosingTag(bodyXml) + 1;
                    int lengthToRemove = (lastElementIndex);
                    string output = bodyXml.Remove(0, lengthToRemove);
                    if (output.Length > 0)
                        recursiveElementValidation2(output);
                }
                else
                    throw new Exception($"Invalid xml! No closing tag found for {elName}");
            }
            else if (bodyXml.Contains("<")) //possibly the body still has element but the start is the element value instead like test 8
            {
                bool elHasAttribute = false;
                List<string> attributes = new List<string>();
                int startIndexElement = bodyXml.IndexOf('<') + 1;
                string elName = bodyXml.Substring(startIndexElement, getLength(startIndexElement, bodyXml));
                if (elName.Contains(" "))
                {
                    attributes.AddRange(elName.Split(' '));
                    //if (attributes.Count == 1)
                    //    throw new Exception("Invalid Xml input string, Element name cannot have spaces!");
                    elName = attributes[0];
                    elHasAttribute = true;
                }

                string closingElName = $"</{elName}>";
                string closingSelfElName = elName.EndsWith("/") ? $"<{elName}>" : $"<{elName}/>";

                if (bodyXml.Contains(closingElName))
                {
                    int attributeLength = 0;
                    if (elHasAttribute)
                    {
                        for (int i = 1; i < attributes.Count; i++)
                            attributeLength = attributes[i].Length + 1; //+1 to include space 

                    }

                    int lastElementIndex = FindEndRootElement(elName, bodyXml) - (startIndexElement - 1);
                    int startIndex = findElementClosingTag(bodyXml);
                    string body = bodyXml.Substring(startIndex + 1, lastElementIndex - attributeLength); //body might be Element value, or nested elements
                    if (body.Length > 0)
                        recursiveElementValidation2(body); //if element value contains nested element, recursive will keep going until it does not find an element

                    if (lastElementIndex < bodyXml.Length) // if value less, means there is still more content to parse 
                    {
                        int lengthToRemove = ((lastElementIndex - attributeLength) + closingElName.Length + startIndex + 1) ;
                        string output = bodyXml.Remove(0, lengthToRemove);
                        if (output.Length > 0)
                            recursiveElementValidation2(output);
                    }

                }
                else if (bodyXml.Contains(closingSelfElName) || String.Concat(bodyXml.Where(c => !Char.IsWhiteSpace(c))).Contains(closingSelfElName)) //cater the scenario where an element self close
                {
                    int lastElementIndex = findElementClosingTag(bodyXml) + 1;
                    int lengthToRemove = (lastElementIndex);
                    string output = bodyXml.Remove(0, lengthToRemove);
                    if (output.Length > 0)
                        recursiveElementValidation2(output);
                }
                else
                    throw new Exception($"Invalid xml! No closing tag found for {elName}");
                
                //Console.WriteLine("yahoo\t" + bodyXml);
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
