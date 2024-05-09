using System;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApp1.src.AST;

namespace WindowsFormsApp1.src
{
    internal class Parser
    {
        private List<Token> tokens;
        private int pos = 0;
        private int errorPos = 0;
        private Dictionary<string, TokenType> tokenTypeList = new tokensList().tokenTypeList;
        ErrorHandler error;

        public Parser(List<Token>listTokens, ErrorHandler errors)
        {
            tokens = listTokens;
            error = errors;
        }

        dynamic tryFinds(int localPos, params TokenType[] expected)
        {
            var tryParseNext = matchTo(localPos, expected);
            if (tryParseNext != null)
            {
                error.addError("На позиции " + (errorPos) + " получен неизвестный символ" + " ожидался " + expected[0].name);
                tokens.Remove(tokens[pos]);
                return tryParseNext;
            }
            else
            {
                changeNodes(expected[0]);
                return false;
            }
        }
        
        void changeNodes(TokenType tokenType)
        {
            List<Token> newTokens = new List<Token>();
            int iteration = 0;

            Token changeableToken = new Token(tokenType, "aas", pos);


            if (tokens.Count >= 6)
            {
                foreach (Token val in tokens)
                {
                    if (iteration == pos)
                        newTokens.Add(changeableToken);
                    else
                        newTokens.Add(val);
                    iteration++;
                }
                tokens = newTokens;
            }
            else
            {
                if (
                    //tokens[pos].type.name == tokenTypeList["CONSTANT"].name ||
                    //tokens[pos].type.name == tokenTypeList["NUMERIC"].name ||
                    //tokens[pos].type.name == tokenTypeList["ASSIGMENT"].name ||
                    //tokens[pos].type.name == tokenTypeList["NUMBER"].name ||
                    //tokens[pos].type.name == tokenTypeList["SEMICOLON"].name
                    tokens[pos].type.name == tokenTypeList["LSHIFTOP"].name ||
                    tokens[pos].type.name == tokenTypeList["COUT"].name ||
                    tokens[pos].type.name == tokenTypeList["ENDL"].name ||
                    tokens[pos].type.name == tokenTypeList["ENDS"].name ||
                    tokens[pos].type.name == tokenTypeList["FLUSH"].name ||
                    tokens[pos].type.name == tokenTypeList["SEMICOLON"].name
                    )
                {
                    tokens.Insert(pos, changeableToken);
                }
                else
                {
                    foreach (Token val in tokens)
                    {
                        if (iteration == pos)
                            newTokens.Add(changeableToken);
                        else
                            newTokens.Add(val);
                        iteration++;
                    }
                    tokens = newTokens;
                }
            }
            // */

            /*
            if (tokens.Count >= 6)
            {
                foreach (Token val in tokens)
                {
                    if (iteration == pos)
                        newTokens.Add(changeableToken);
                    else
                        newTokens.Add(val);
                    iteration++;
                }
                tokens = newTokens;
            }
            else
                tokens.Insert(pos, changeableToken);

            */

            pos += 1;
        }

        Token matchTo(int pos, params TokenType[] expected)
        {
            if (pos < tokens.Count)
            {
                Token currentToken = tokens[pos];
                var aa = expected.FirstOrDefault(type => type.name == currentToken.type.name);
                if (aa != null)
                {
                    this.pos += 1;
                    return currentToken;
                }
            }
            return null;
        }
        Token match(params TokenType[] expected)
        {
            errorPos += 1;
            if (pos < tokens.Count)
            {
                Token currentToken = tokens[pos];
                var aa = expected.FirstOrDefault(type => type.name == currentToken.type.name);
                if (aa != null)
                {
                    pos += 1;
                    return currentToken;
                }
                else
                {
                    var t = tryFinds(pos +1, expected);
                    if (!(t is bool))
                        return t;
                }
            }
            return null;
        }

        Token require(params TokenType[] expected)
        {
            Token token = match(expected);
            if(token == null)
            {
                error.addError("На позиции " + (errorPos) + " ожидается " + expected[0].name);
                return null;
            }
            
            return token;
        }
       

        void parseExpression()
        {
            //var variableName = require(tokenTypeList["VARIABLE"]);
            //var constantNode = require(tokenTypeList["CONSTANT"]);
            //var dataTypeNode = require(tokenTypeList["NUMERIC"]);
            //var assignOperator = require(tokenTypeList["ASSIGMENT"]);
            //var numberToken = require(tokenTypeList["NUMBER"]);
            
        }
        public ExpressionNode WordsParser(int i)
        {
            if (tokens[i].type.name == "STRING")
            {
                i++;
                var word = WordsParser(i);
                return new ExpressionNode();
            }
            return null;
        }
        public ExpressionNode parseCode()
        {
            StatementsNode root = new StatementsNode();
            while (pos < tokens.Count)
            {                
                //parseExpression();
                var CoutNode = require(tokenTypeList["COUT"]);
                var LShOpNode = require(tokenTypeList["LSHIFTOP"]);
                var LParNode = require(tokenTypeList["LPAR"]);



                var StringNode = require(tokenTypeList["STRING"]);
                int i = pos;
                var word = WordsParser(i);
                require(tokenTypeList["LPAR"]);
                i = pos;
                try
                {
                    if (tokens[i].value == ";")
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                }
                require(tokenTypeList["LSHIFTOP"]);
                i = pos;
                try
                {
                    if (tokens[i].value == null)
                    {
                        error.addError("На позиции " + i + " ожидается ENDL, ENDL или FLUSH");
                        break;
                    }
                    if (tokens[i].value == "endl")
                    {
                        break;
                    }
                    if (tokens[i].value == "ends")
                    {
                        break;
                    }
                    if (tokens[i].value == "flush")
                    {
                        break;
                    }
                    error.addError("На позиции " + i + " ожидается ENDL, ENDL или FLUSH");
                }
                catch (Exception e)
                {

                }              
                //var EndlNode = require(tokenTypeList["ENDL"]);
                //var EndsNode = require(tokenTypeList["ENDS"]);
                //var FlushNode = require(tokenTypeList["FLUSH"]);
                if (require(tokenTypeList["SEMICOLON"]) == null) ;
                break;
            }
            if(error.errorsCount() == 0)
                error.addError("Программа отработала в штатном режиме.");
            return root;
        }

        public ExpressionNode parseLab6()
        {
            
            

            return null;
        }
    }
}
