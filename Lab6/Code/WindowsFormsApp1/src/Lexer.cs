using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.src
{
    internal class Lexer
    {
        public string code;
        public int pos;
        private List<Token> tokenList = new List<Token>();
        private Dictionary<string, TokenType> tokenTypesValues = new tokensList().tokenTypeList;
        ErrorHandler error;
        public Lexer(string code, ErrorHandler errors)
        {
            this.code = code;
            error = errors;
        }
        public List<Token> lexerAnalysis()
        {
            while (nextToken()) { }
            return tokenList;
        }
        bool nextToken()
        {
            if(pos >= code.Length)
                return false;
            foreach (var value in tokenTypesValues)
            {
                var tokenTypeValue = value.Value;
                var regex = new Regex('^' + tokenTypeValue.regexp + '$');
                var result = code.Substring(pos).Trim().Split('\n')[0].Split('\r')[0].Split(' ')[0];
                if (result != null)
                {
                    if (regex.IsMatch(result))
                    {
                        Token token = new Token(tokenTypeValue, result, pos);
                        pos += result.Length+1;
                        tokenList.Add(token);
                        error.clearErrors();
                        return true;
                    }
                    else
                        error.addError("Неизвестное значение на позиции " + pos);
                }
            }
            return false;
        }
    }
}
