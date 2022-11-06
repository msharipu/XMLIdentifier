using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace XMLIdentifier
{
    internal class Program
    {
        int TestCount = 1;
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
            string test20 = "<Design><Test /><Test1><</Test1></Design>";
            string test21 = "<Design></Test><Test1></Design>";
            string test22 = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\"><xsl:template match=\"/\"><html><body><h2>My CD Collection</h2><table border=\"1\"><tr><th style=\"text-align:left\">Title</th><th style=\"text-align:left\">Artist</th></tr><xsl:for-each select=\"catalog/cd\"><tr><td><xsl:value-of select=\"title\"/></td><td><xsl:value-of select=\"artist\"/></td></tr></xsl:for-each></table></body></html></xsl:template></xsl:stylesheet>";
            string test23 = "<?xml version=\"1.0\"?><xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"><xs:element name=\"Book\"><xs:complexType><xs:sequence><xs:element name=\"Title\" type=\"xs:string\"/><xs:element name=\"Author\" type=\"xs:string\" minOccurs=\"1\" maxOccurs=\"2\"/><xs:element name=\"Publication_Year\" type=\"xs:positiveInteger\"/><xs:element name=\"Category\" type=\"xs:string\"/><xs:element name=\"Language\" type=\"xs:string\" default=\"English\"/><xs:element name=\"Pages\" type=\"xs:postiveInteger\"/><xs:element name=\"Number_of_Chapters\" type=\"xs: postiveInteger \"/><xs:element name=\"Chap_1\" type=\"xs:string\" minOccurs=\"1\" maxOccurs=\"1\"/><xs:element name=\"Chap_2\" type=\"xs:string\" minOccurs=\"1\" maxOccurs=\"1\"/><xs:element name=\"Chap_3\" type=\"xs:string\" minOccurs=\"1\" maxOccurs=\"1\"/><!-- Similarly the number of chapters can be represented separately--><xs:element name=\"Reference\" type=\"xs:string\"/></xs:sequence></xs:complexType></xs:element></xs:schema>";
            string test24 = "<?xml version=\"1.0\"?><xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"><xs:element name=\"Book\"><xs:complexType><xs:sequence><xs:element name=\"Title\" type=\"xs:string\"/><xs:element name=\"Author\" type=\"xs:string\" minOccurs=\"1\" maxOccurs=\"2\"/><xs:element name=\"Publication_Year\" type=\"xs:positiveInteger\"/><xs:element name=\"Category\" type=\"xs:string\"/><xs:element name=\"Language\" type=\"xs:string\" default=\"English\"/><xs:element name=\"Pages\" type=\"xs:postiveInteger\"/><xs:element name=\"Number_of_Chapters\" type=\"xs: postiveInteger \"/><xs:element name=\"Chap_1\" type=\"xs:string\" minOccurs=\"1\" maxOccurs=\"1\"/><xs:element name=\"Chap_2\" type=\"xs:string\" minOccurs=\"1\" maxOccurs=\"1\"/><xs:element name=\"Chap_3\" type=\"xs:string\" minOccurs=\"1\" maxOccurs=\"1\"/><!-- Similarly the number of chapters can be represented separately--><xs:element name=\"Reference\" type=\"xs:string\"/><xs:element name=\"Reference\" type=\"xs:string\"/><xs:element name=\"Reference\" type=\"xs:string\"/><xs:element name=\"Reference\" type=\"xs:string\"/></xs:sequence></xs:complexType></xs:element></xs:schema>";
            string test25 = "<Design><Code>hello world</Code></Design><test></test>";
            string test26 = "<Design><Code attr=\"123\" attr>hello world</Code><XCode attr=>hello world</XCode><YCode attr=\"123\" _123=\"\">hello world</YCode></Design>";
            string test27 = "<Design><XCode attr=>hello world</XCode><YCode attr=\"123\" _123=\"\">hello world</YCode></Design>";
            string test28 = "<Design><YCode attr=\"123\" _123=\"\">hello world</YCode></Design>";
            string test29 = "<Design><Code  >&</Code></Design>";
            string test30 = "<Design><Code  >&lt; &gt;</Code></Design>";
            string test31 = "<Design><Code  >;&</Code></Design>";
            string test32 = "<Design><Code  >&gt &</Code></Design>";
            string test33 = "<Design><Code  >& &gt</Code></Design>";
            string test34 = "<Design><!-- This is an invalid -- comment --><Code  >& &gt</Code></Design>";
            string test35 = "<Design><!-- This is an invalid--comment --><Code  >& &gt</Code></Design>";
            string test36 = "<Design>123&<Code  >& &gt</Code></Design>";

            //Console.WriteLine("Output: " + p.DetermineSxml(test1) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test2) + "\n"); //output False, invalid root
            //Console.WriteLine("Output: " + p.DetermineSxml(test3) + "\n"); //output False, invalid root
            //Console.WriteLine("Output: " + p.DetermineSxml(test4) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test5) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test6) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test7) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test8) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test9) + "\n"); //output False, no closing element Code
            //Console.WriteLine("Output: " + p.DetermineSxml(test10) + "\n"); //output False, no closing element Code
            //Console.WriteLine("Output: " + p.DetermineSxml(test11) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test12) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test13) + "\n"); //output False, case sensitive element name failed
            //Console.WriteLine("Output: " + p.DetermineSxml(test14) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test15) + "\n"); //output True
            Console.WriteLine("Output: " + p.DetermineSxml(test16) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test17) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test18) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test19) + "\n"); //output True
            //Console.WriteLine("Output: " + p.DetermineSxml(test20) + "\n"); //output False, invalid element value with < character
            //Console.WriteLine("Output: " + p.DetermineSxml(test21) + "\n"); //output False, invalid closing element upfront
            //Console.WriteLine("Output: " + p.DetermineSxml(test22) + "\n"); //output True, 
            //Console.WriteLine("Output: " + p.DetermineSxml(test23) + "\n"); //output True, 
            //Console.WriteLine("Output: " + p.DetermineSxml(test24) + "\n"); //output True, 
            //Console.WriteLine("Output: " + p.DetermineSxml(test25) + "\n"); //output False, more than 1 root tags 
            //Console.WriteLine("Output: " + p.DetermineSxml(test26) + "\n"); //output False, more than 1 root tags 
            //Console.WriteLine("Output: " + p.DetermineSxml(test27) + "\n"); //output False, more than 1 root tags 
            //Console.WriteLine("Output: " + p.DetermineSxml(test28) + "\n"); //output True, 
            //Console.WriteLine("Output: " + p.DetermineSxml(test29) + "\n"); //output False, Invalid character detected
            //Console.WriteLine("Output: " + p.DetermineSxml(test30) + "\n"); //output True,
            //Console.WriteLine("Output: " + p.DetermineSxml(test31) + "\n"); //output False, Invalid character detected
            //Console.WriteLine("Output: " + p.DetermineSxml(test32) + "\n"); //output False, Invalid character detected
            //Console.WriteLine("Output: " + p.DetermineSxml(test33) + "\n"); //output False, Invalid character detected
            //Console.WriteLine("Output: " + p.DetermineSxml(test34) + "\n"); //output False, Invalid character detected
            //Console.WriteLine("Output: " + p.DetermineSxml(test35) + "\n"); //output False, Invalid character detected
            //Console.WriteLine("Output: " + p.DetermineSxml(test36) + "\n"); //output False, Invalid character detected
            Console.ReadKey();
        }

        bool DetermineSxml(string sxml)
        {
            try
            {
                Console.WriteLine(TestCount++.ToString() + ")");
                Console.WriteLine("Input: " + sxml);

                if (sxml.StartsWith("<?"))
                    sxml = sxml.Remove(0, sxml.IndexOf(">") + 1);
                //recursiveElementValidation2(sxml);
                recursiveElementValidation2(sxml, true);

                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message + "\t");
                return false;
            }
        }

        //private void recursiveElementValidation2(string bodyXml)
        private void recursiveElementValidation2(string bodyXml, bool isRoot = false)
        {
            //Console.WriteLine(bodyXml);

            if (bodyXml.Contains("<") && !bodyXml.Contains(">"))
                throw new Exception("There is no closing element");
            #region COMMENTED OUT 
            //else if (bodyXml.StartsWith("<") && !bodyXml.Substring(1).Equals("//"))
            //{
            //    bool elHasAttribute = false;
            //    List<string> attributes = new List<string>();
            //    string elName = bodyXml.Substring(1, getLength(1, bodyXml));
            //    if (elName.Contains(" "))
            //    {
            //        attributes.AddRange(elName.Split(' '));
            //        //if (attributes.Count == 1)
            //        //    throw new Exception("Invalid Xml input string, Element name cannot have spaces!");
            //        elName = attributes[0];
            //        elHasAttribute = true;
            //    }

            //    string closingElName = $"</{elName}>";
            //    string closingSelfElName = elName.EndsWith("/") ? $"<{elName}>" : $"<{elName}/>";

            //    if (bodyXml.Contains(closingElName)) //element name are case sensitive
            //    {
            //        int attributeLength = 0;
            //        if (elHasAttribute)
            //        {
            //            for (int i = 1; i < attributes.Count; i++)
            //                attributeLength = attributes[i].Length + 1; //+1 to include space 

            //        }

            //        int lastElementIndex = FindEndRootElement(elName, bodyXml);
            //        int startIndex = findElementClosingTag(bodyXml);
            //        string body = bodyXml.Substring(startIndex + 1, lastElementIndex - attributeLength); //body might be Element value, or nested elements
            //        if(body.Length > 0)
            //            recursiveElementValidation2(body); //if element value contains nested element, recursive will keep going until it does not find an element

            //        if (lastElementIndex < bodyXml.Length) // if value less, means there is still more content to parse 
            //        {
            //            int lengthToRemove = (lastElementIndex - attributeLength) + closingElName.Length + startIndex + 1;
            //            string output = bodyXml.Remove(0, lengthToRemove);
            //            if (output.Length > 0)
            //                recursiveElementValidation2(output);
            //        }

            //    }
            //    else if (String.Concat(bodyXml.Where(c => !Char.IsWhiteSpace(c))).Contains(closingSelfElName)) //cater the scenario where an element self close
            //    {
            //        int lastElementIndex = findElementClosingTag(bodyXml) + 1;
            //        int lengthToRemove = (lastElementIndex);
            //        string output = bodyXml.Remove(0, lengthToRemove);
            //        if (output.Length > 0)
            //            recursiveElementValidation2(output);
            //    }
            //    else
            //        throw new Exception($"Invalid xml! No closing tag found for {elName}");
            //}
            #endregion
            else if (bodyXml.Contains("<")) //possibly the body still has element but the start is the element value instead like test 8
            {
                if (bodyXml.StartsWith("<!--")) // if comment, find the closing and continue with next element available
                {
                    string closingComment = "-->";
                    if (bodyXml.Substring(0, bodyXml.IndexOf(closingComment)).Contains("--"))
                        throw new Exception("Invalid comment detected");

                    string output = bodyXml.Remove(0, bodyXml.IndexOf(closingComment) + closingComment.Length);
                    if (output.Length > 0)
                        recursiveElementValidation2(output);

                    return;
                }
                else if(bodyXml.IndexOf('<') > 0 && validateElementBodyValue(bodyXml)) // added extra validation if there is value in element body
                    throw new Exception("Invalid character detected");

                bool elHasAttribute = false;
                List<string> attributes = new List<string>();
                int startIndexElement = bodyXml.IndexOf('<') + 1;
                string elName = bodyXml.Substring(startIndexElement, getLength(startIndexElement, bodyXml));
                if (elName.StartsWith("/"))
                    throw new Exception("Invalid xml string! Opening element not found!");

                if (elName.Contains(" "))
                {
                    attributes.AddRange(elName.Split(' '));
                    //if (attributes.Count == 1)
                    //    throw new Exception("Invalid Xml input string, Element name cannot have spaces!");
                    elName = attributes[0];
                    validateElementAttribute(attributes.ToArray()); // validate the element attribtue
                    elHasAttribute = true;
                }

                string closingElName = $"</{elName}>";
                // update cater scenario where element self close and has attributes
                string closingSelfElName = "";
                if (elHasAttribute && attributes.LastOrDefault().EndsWith("/"))
                {
                    closingSelfElName = String.Concat("<", String.Join(" ", attributes.ToArray()), ">");
                }
                else
                    closingSelfElName = elName.EndsWith("/") ? $"<{elName}>" : $"<{elName}/>";

                if (bodyXml.Contains(closingElName))
                {
                    int attributeLength = 0;
                    if (elHasAttribute)
                    {
                        for (int i = 1; i < attributes.Count; i++)
                            attributeLength += attributes[i].Length + 1; //+1 to include space 
                        //Console.Write("element has attribute\t");
                    }

                    int lastElementIndex = FindEndRootElement(elName, bodyXml, isRoot) - (startIndexElement - 1);
                    int startIndex = findElementClosingTag(bodyXml);
                    string body = bodyXml.Substring(startIndex + 1, lastElementIndex - attributeLength); //body might be Element value, or nested elements
                    if (body.Length > 0)
                        recursiveElementValidation2(body); //if element value contains nested element, recursive will keep going until it does not find an element

                    if (lastElementIndex < bodyXml.Length) // if value less, means there is still more content to parse 
                    {
                        int lengthToRemove = ((lastElementIndex - attributeLength) + closingElName.Length + startIndex + 1);
                        string output = bodyXml.Remove(0, lengthToRemove);
                        if (output.Length > 0)
                            recursiveElementValidation2(output);
                    }

                }
                //cater the scenario where an element self close

                else if (bodyXml.Contains(closingSelfElName) || String.Concat(bodyXml.Where(c => !Char.IsWhiteSpace(c))).Contains(closingSelfElName))
                {
                    //Console.Write("Found closing self element name \t");
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
            //else if (validateElementBodyValue(bodyXml))
            else if (validateElementBodyValue(bodyXml))
                throw new Exception("Invalid character detected");
        }

        private bool validateElementBodyValue(string bodyXml)
        {
            bool invalidFound = false;
            if (bodyXml.Contains("&"))
            {
                int length1 = 4;
                int length2 = 5;

                for (int i = bodyXml.IndexOf('&'); i < bodyXml.Length; i++) //index of first '&'
                {
                    if (i + 1 == bodyXml.Length)
                    {
                        invalidFound = true;
                        break;
                    }
                    else if (bodyXml.Substring(i, length1) == "&lt;" || bodyXml.Substring(i, length1) == "&gt;")
                    {
                        i = i + length1;
                        continue;
                    }
                    else if (bodyXml.Substring(i, 5) == "&amp;" || bodyXml.Substring(i, 5) == "&apos;" ||
                        bodyXml.Substring(i, 5) == "&quot;")
                    {
                        i = i + length2;
                        continue;
                    }
                    else
                    {
                        invalidFound = true;
                        break;
                    }
                        //throw new Exception("Invalid character detected");
                }
            }

            return invalidFound;
        }

        /// <summary>
        /// Check if attribute format is correct 
        /// </summary>
        /// <param name="array"></param>
        private void validateElementAttribute(string[] array)
        {
            for (int i = 1; i < array.Length; i++) //loop through array element
            {
                string attributeName = "";
                int countQuote = 0;

                if (array[i] == null || array[i] == "" || (array[i].Length == 1 && array[i] == "/"))
                    continue;
                else if (attributeName != "" && attributeName.Equals(array[i], StringComparison.OrdinalIgnoreCase))
                    throw new Exception("Attribute name duplicate detected");
                else if (!array[i].Contains("="))
                    throw new Exception("Invalid element");

                for (int j = 0; j < array[i].Length; j++) //loop through the strings in array element
                {
                    if (countQuote > 2 || ((j + 1) == array[i].Length) && countQuote == 0) //if quote more than 2, error out. no quote found, also error out
                        throw new Exception("Invalid Element attribute");
                    else if (array[i][j] == '=')
                    {
                        attributeName = array[i].Substring(0, j);
                        if ((attributeName == null || attributeName == "") ||
                            (attributeName.Contains("<") || attributeName.Contains(">") || attributeName.Contains("&")) ||
                            (!char.IsLetter(attributeName[0]) && attributeName[0] != '_'))
                            throw new Exception("Invalid attribute name");
                    }
                    else if (array[i][j] == '\"')
                        countQuote++;
                }
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
            string endRootElement = "</" + rootElementName + ">";
            int endRootIndex = 0;

            if (sxml.Contains(endRootElement))
            {
                endRootIndex = sxml.IndexOf(endRootElement);
                if (isRoot && (sxml.Substring(endRootIndex).IndexOf(">") + endRootIndex) + 1 < sxml.Length) //the root node should be the end, if there is value outside of '>' then consider as invalid node
                    throw new Exception("Invalid root tag!");

                return endRootIndex - (endRootElement.Length - 1);
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
