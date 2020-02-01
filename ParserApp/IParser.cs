using CoreApp;
using System;

namespace ParserApp
{
    public interface IParser
    {
         IEntity GetParser(byte[] byteData);
    } 
}
