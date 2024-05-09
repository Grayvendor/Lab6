# Lab6
1-е задание: <br />
(6) Построить РВ, описывающее шестнадцатеричный код (HEX) цвета (длиной 6). <br />
^#([A-Fa-f0-9]{6})$ <br />
#FFFFFF <br />
сage -> # <br />
letter -> a | b | c | ... | z | A | B | C | ... | Z | <br />
digit -> 0 | 1 | ... | 9 <br />
<br />
Грамматика: <br />
EXPR -> сage EXPREM1 <br />
EXPRREM1 -> digit EXPRREM2 | letter EXPRREM2 <br />
EXPRREM2 -> digit EXPRREM3 | letter EXPRREM3 <br />
EXPRREM3 -> digit EXPRREM4 | letter EXPRREM4 <br />
EXPRREM4 -> digit EXPRREM5 | letter EXPRREM5 <br />
EXPRREM5 -> digit EXPRREM6 | letter EXPRREM6 <br />
EXPRREM6 -> end <br />
<br />
![L6_1](https://github.com/Grayvendor/Lab6/assets/160223599/ff9572ed-b4f1-4898-b2b8-5d904042c5d3) <br />
![Снимок экрана 2024-05-09 212730](https://github.com/Grayvendor/Lab6/assets/160223599/4139ee79-4bc9-45cf-873f-878a5fd3c725) <br />
2-е задание:<br />
(8) Построить РВ, описывающее номера карт, принадлежащих платежной системе Maestro Card. <br />
^(5[0-9]{2}|6[0-9]{2})([0-9]{13})$ <br />
5234123412341234<br />
6234123412341234<br />
<br />
грамматика:<br />
code -> 5 | 6<br />
digit -> 0 | 1 | ... | 9<br />
<br />
EXPR -> code EXPREM1<br />
EXPRREM1 -> digit EXPRREM2<br />
EXPRREM2 -> digit EXPRREM3<br />
EXPRREM3 -> digit EXPRREM4<br />
EXPRREM4 -> digit EXPRREM5<br />
EXPRREM5 -> digit EXPRREM6<br />
EXPRREM6 -> digit EXPRREM7<br />
EXPRREM7 -> digit EXPRREM8<br />
EXPRREM8 -> digit EXPRREM9<br />
EXPRREM9 -> digit EXPRREM10<br />
EXPRREM10 -> digit EXPRREM11<br />
EXPRREM11 -> digit EXPRREM12<br />
EXPRREM13 -> digit EXPRREM14<br />
EXPRREM14 -> digit EXPRREM15<br />
EXPRREM15 -> digit EXPRREM16<br />
EXPRREM16 -> end<br />
<br />
![L6_2](https://github.com/Grayvendor/Lab6/assets/160223599/25fb2a99-29ee-4f33-8a02-1c04e336f436)<br />
![Снимок экрана 2024-05-09 212745](https://github.com/Grayvendor/Lab6/assets/160223599/33a72442-ff9d-4a30-ab43-d747e75a03cc)<br />
3-е задание:<br />
(15) Построить РВ для проверки надежности пароля. Требования к надежности пароля: имеет длину не менее 12 символов. Хотя бы одна заглавная буква. Хотя бы одна строчная буква. Хотя бы одна цифра. Хотя бы один специальный символ из списка: #?!@$_%/^|&*-\.
^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[#?!@$_%^|&*\\-\\\\.])[A-Za-z\\d#?!@$_%^|&*\\-\\\\.]{12,}$<br />
Pa$$w0rd!123<br />
<br />
![Снимок экрана 2024-05-09 212756](https://github.com/Grayvendor/Lab6/assets/160223599/efa51330-72b2-4bf6-aac4-2260f22f518d)<br />
