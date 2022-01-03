using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Alunos: Gabriel Henrique Braz e Marlon Bento.

namespace Labirinto_2019
{
    class Program
    {
        public struct Posicao
        {
            public int x;
            public int y;
            public Posicao(int a, int b)
            {
                x = a;
                y = b;
            }
        }
        static void Menu()
        {
            //Menu que aparece antes de começar.
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write((char)9555);

            for (int i = 0; i <= 76; i++)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write((char)9552);
            }
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write((char)9557);

            for (int i = 0; i <= 22; i++)
            {
                Console.Write("\n" + (char)9553 + "\t\t\t\t\t\t\t\t\t      " + (char)9553);
            }
            Console.Write("\n" + (char)9561);

            for (int i = 0; i <= 76; i++)
            {
                Console.Write((char)9552);
            }
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write((char)9564);
            Console.SetCursorPosition(33, 8);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Jogo do labirinto ");
            Console.SetCursorPosition(35, 9);
            Console.WriteLine("use as teclas:");
            Console.SetCursorPosition(27, 10);
            Console.WriteLine("(A) para mover para a esquerda");
            Console.SetCursorPosition(27, 11);
            Console.WriteLine("(D) para mover para a diteita");
            Console.SetCursorPosition(27, 12);
            Console.WriteLine("(W) para ir para cima");
            Console.SetCursorPosition(27, 13);
            Console.WriteLine("(S) para ir para baixo ");
            Console.SetCursorPosition(27, 15);
            Console.WriteLine("Prescione (ENTER) Para Começa");
            Console.BackgroundColor = ConsoleColor.Black;

        }
        static void printMap(char[,] map)
        {
            //Funçao usada para mostrar o mapa.
            Console.Clear();
            Console.Write("\n\n");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.Write("\n");
            }
        }
        static char[,] fase1(char[,] map)
        {
            //manufatura da fase 1.
            int reg;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                //preencher mapa parede esquerda.
                map[i, 0] = (char)9553;
            }
            for (int j = 0; j < map.GetLength(1); j++)
            {
                //preencher mapa parede de baixo.
                map[7, j] = (char)9552;
            }
            for (int a = 0; a < map.GetLength(0); a++)
            {
                //preenche mapa parede do lado.
                map[a, 11] = (char)9553;
            }
            for (int b = 0; b < map.GetLength(1); b++)
            {
                //preenche a parede de cima.
                map[0, b] = (char)9552;
            }
            for (int i = 1; i < map.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < map.GetLength(1) - 1; j++)
                {
                    map[i, j] = '#';
                }
            }
            for (reg = 1; reg < 6; reg++)
            {
                map[reg, 1] = ' ';
            }
            for (reg = 1; reg < 6; reg++)
            {
                map[1, reg] = ' ';
            }
            map[2, 5] = ' '; map[3, 5] = ' ';
            for (reg = 5; reg < 10; reg++)
            {
                map[2, reg] = ' ';
            }
            for (reg = 1; reg < 7; reg++)
            {
                map[5, reg] = ' ';
            }
            for (reg = 6; reg < 9; reg++)
            {
                map[6, reg] = ' ';
            }
            map[6, 9] = ']';
            map[4, 10] = ' ';
            map[3, 10] = ' ';
            return map;
        }
        static char[,] fase2(char[,] map)
        {
            //Faça a fase 2 aqui!
            return map;
        }
        static char[,] gameWin(char[,] map)
        {
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = ' ';
                }
            }
            map[0, 1] = 'V';
            map[0, 2] = 'I';
            map[0, 3] = 'T';
            map[0, 4] = 'O';
            map[0, 5] = 'R';
            map[0, 6] = 'I';
            map[0, 7] = 'A';
            return map;
        }
        static char[,] gameOver(char[,] map)
        {
            //Muda a matriz caso o personagem morra.
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = ' ';
                }
            }
            char[] marlao = { 'G', 'A', 'M', 'E', 'O', 'V', 'E', 'R' };
            for (int j = 0; j < map.GetLength(0); j++)
            {
                map[0, j] = marlao[j];
            }
            return map;
        }
        static char[,] moveTo(char[,] fase, Posicao xy, int[] limite)
        {
            ConsoleKey key = Console.ReadKey().Key;
            if(key == ConsoleKey.Z)
            {
                fase = gameOver(fase);
                return fase;
            }
            if (key == ConsoleKey.D)
            {
                //Caso o jogador pressione D o personagem anda na matriz.
                fase[xy.x, xy.y] = ' ';
                //Caso obstaculo.
                if (fase[xy.x, xy.y + 1] == '#')
                {
                    fase = gameOver(fase);
                    return fase;
                }
                if(fase[xy.x,xy.y + 1] == (char)9552 || fase[xy.x,xy.y + 1] == (char)9553)
                {
                    fase = gameOver(fase);
                    return fase;
                }
                if(fase[xy.x,xy.y+1] == ']')
                {
                    fase = gameWin(fase);
                    return fase;
                }
                //Substituindo pelo char do personagem.
                fase[xy.x, xy.y + 1] = '>';
                return fase;
            }
            if (key == ConsoleKey.A)
            {
                //ir pra esquerda da matriz.
                fase[xy.x, xy.y] = ' ';
                //Caso obtaculo.
                if(fase[xy.x,xy.y-1] == '#')
                {
                    fase = gameOver(fase);
                    return fase;
                }
                if (fase[xy.x, xy.y - 1] == (char)9552 || fase[xy.x, xy.y - 1] == (char)9553)
                {
                    fase = gameOver(fase);
                    return fase;
                }
                if (fase[xy.x, xy.y - 1] == ']')
                {
                    fase = gameWin(fase);
                    return fase;
                }
                fase[xy.x, xy.y - 1] = '<';
                return fase;
            }
            if (key == ConsoleKey.S)
            {
                //vai pra baixo na matriz.
                fase[xy.x, xy.y] = ' ';
                //Caso obstaculo.
                if(fase[xy.x+1,xy.y] == '#')
                {
                    fase = gameOver(fase);
                    return fase;
                }
                if (fase[xy.x + 1, xy.y] == (char)9552 || fase[xy.x + 1, xy.y] == (char)9553)
                {
                    fase = gameOver(fase);
                    return fase;
                }
                if (fase[xy.x + 1, xy.y] == ']')
                {
                    fase = gameWin(fase);
                    return fase;
                }
                fase[xy.x + 1, xy.y] = 'v';
                return fase;
            }
            if (key == ConsoleKey.W)
            {
                //vai pra cima na matriz.
                fase[xy.x, xy.y] = ' ';
                //Caso obstaculo.
                if (fase[xy.x - 1, xy.y] == '#')
                {
                    fase = gameOver(fase);
                    return fase;
                }
                if (fase[xy.x - 1, xy.y] == (char)9552 || fase[xy.x - 1, xy.y] == (char)9553)
                {
                    fase = gameOver(fase);
                    return fase;
                }
                if (fase[xy.x - 1, xy.y] == ']')
                {
                    fase = gameWin(fase);
                    return fase;
                }
                fase[xy.x - 1, xy.y] = '^';
                return fase;
            }
            return fase;

        }
        static Posicao headHunter (char[,] map)
        {
            Posicao pos = new Posicao(0,0);
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if(map[i,j] == '>' || map[i,j] == '<' || map[i,j] == '^' || map[i,j] == 'v')
                    {
                        pos.x = i;
                        pos.y = j;
                        return pos;
                    }
                    else
                    {
                        pos.x = 0;
                        pos.y = 0;
                    }
                }
            }
            return pos;
        }
        static void Main(string[] args)
        {
            bool control;
            bool controlMenu = true; //controla o menu do jogo;
            char opcao; //sera usada dentro do loop que controla o menu;
            int[] limite = { 8, 12 }; //guarda o tamanho do mapa que será usado depois.
            Posicao posicao; //guarda a posicao atual do jogador na matriz.
            //criacao da matriz que será o mapa do jogo:
            char[,] mapa = new char[limite[0], limite[1]];
            
            while(controlMenu == true)
            {
                mapa = fase1(mapa);
                Menu();
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    control = true;
                    Console.Clear();
                    posicao.x = 1;
                    posicao.y = 2;
                    mapa[posicao.x, posicao.y] = '>';
                    while (control == true)
                    {

                        control = false;
                        printMap(mapa);
                        Console.WriteLine("Aperte para movimentar");
                        Console.WriteLine("Ou Z para sair do jogo.");
                        mapa = moveTo(mapa, posicao, limite);
                        posicao = headHunter(mapa);
                        if (mapa[0, 1] == 'V')
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Você ganhou o jogo!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("\nDeseja seguir para a fase 2? ");
                            char choices = char.Parse(Console.ReadLine().ToUpper());
                            if(choices == 'S')
                            {
                                //Aqui recebemos no mapa a fase 2 e como control é true ele volta a loopar pra comparar os valores.
                                mapa = fase2(mapa);
                                control = true;
                            }
                            else
                            {
                                control = false;
                            }
                        }
                        else if (mapa[0, 0] == 'G')
                        {
                            Console.Clear();
                            gameOver(mapa);
                            printMap(mapa);
                            control = false;
                        }
                        else
                        {
                            control = true;
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nPartida encerrada. Deseja voltar ao menu? S/N");
                Console.ForegroundColor = ConsoleColor.Gray;
                opcao = char.Parse(Console.ReadLine().ToUpper());
                if(opcao == 'S')
                {
                    Console.Clear();
                }
                else
                {
                    controlMenu = false;
                }
            }
            Console.Clear();
            Console.WriteLine("Pressione qualquer tecla para sair: ");
            Console.ReadKey();
        }
    }
}
