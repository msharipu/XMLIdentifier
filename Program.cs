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


            p.DetermineSxml(test1);
            Console.ReadKey();
        }

        bool DetermineSxml(string sxml)
        {
            List<string> startElement = new List<string>();
            List<string> endElement = new List<string>();
            bool invalidXmlDetected = false;

            for(int i = 0; i < sxml.Length; i++)
            {
                if (invalidXmlDetected)
                    break;

                int opIndex = 0;
                int edIndex = 0;

                if(sxml[i] == '<')
                {
                    if ((sxml[i + 1] ) != '/') // this is an opening element
                    {
                        opIndex = i + 1;
                        int length = 0;

                        for (int j = i+1; j < sxml.Length; j++)
                        {
                            length++;
                            if (sxml[j] != '>')
                                continue;
                            else if(sxml[j] == '<') // if found another opening bracket, then this is an invalid
                            {
                                invalidXmlDetected = true;
                                break;
                            }
                            else // found '>', get the index
                            {
                                //edIndex = j -1 ;
                                edIndex = length -1 ;
                                break;
                            }
                        }

                        if(edIndex == 0) // does not found any closing bracket, invalid
                            invalidXmlDetected = true;
                        else
                        {
                            Console.WriteLine(sxml.Substring(opIndex, edIndex));
                        }
                    }
                }

                
                
            }

            return true;
        }
    }
}
