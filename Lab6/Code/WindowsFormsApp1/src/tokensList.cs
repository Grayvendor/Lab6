using System.Collections.Generic;

namespace WindowsFormsApp1.src
{
    internal class tokensList
    {
        public Dictionary<string, TokenType> tokenTypeList = new Dictionary<string, TokenType>
        {
            { "LPAR", new TokenType("LPAR", "\"+$") },
            { "LSHIFTOP", new TokenType("LSHIFTOP", "\\<<+$") },
            { "COUT", new TokenType("COUT", "cout+$") },
            { "ENDL", new TokenType("ENDL", "endl+$") },
            { "ENDS", new TokenType("ENDS", "ends+$") },
            { "FLUSH", new TokenType("FLUSH", "flush+$") },
            { "SEMICOLON", new TokenType("SEMICOLON", ";+$") },
            { "NLINE", new TokenType("NLINE", "\\/n") },

            { "KARD", new TokenType("KARD", "^(5[0-9]{2}|6[0-9]{2})([0-9]{13})$") },
            { "HEX", new TokenType("HEX", "^#([A-Fa-f0-9]{6})$") },
            { "PASSWORD", new TokenType("PASSWORD", "^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[#?!@$_%^|&*\\-\\\\.])[A-Za-z\\d#?!@$_%^|&*\\-\\\\.]{12,}$") },


            { "STRING", new TokenType("STRING", "(.*)") }



            //{ "SEMICOLON", new TokenType("SEMICOLON", ";") },
            //{ "NUMBER", new TokenType("NUMBER", "^(?:\\+|\\-)?\\d+(?:\\.\\d+)?(?:e(?:\\+|\\-)?\\d+)?$") },
            //{ "ASSIGMENT", new TokenType("ASSIGMENT", "\\:=+$") },
            //{ "NUMERIC", new TokenType("NUMERIC", "numeric") },
            //{ "CONSTANT", new TokenType("CONSTANT", "constant") },
            //{ "VARIABLE", new TokenType("VARIABLE", "[a-z]+$") },
            //{ "UNEXPECTED", new TokenType("UNEXPECTED", "^[a-zA-Z0-9!@#\\$%\\^\\&*\\)\\(+=._:-;]+$") },
        };
    }
}
