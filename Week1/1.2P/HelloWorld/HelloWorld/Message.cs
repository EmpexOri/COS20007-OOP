﻿using System;

namespace HelloWorld
{
    internal class Message
    {
        private string _text;

        public Message(string text)
        {
            _text = text;
        }

        public void Print()
        {
            Console.WriteLine(_text);
        }
    }
}
