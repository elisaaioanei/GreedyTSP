using System;

namespace GreedyTSP
{
    public class PermutationsBacktrackingSolver
    {
        private int n;
        int[] stack;

        public PermutationsBacktrackingSolver(int n)
        {
            this.n = n;
            stack = new int[n];
            for (int i = 0; i < stack.Length; i++)
            {
                stack[i] = -1;
            }
        }

        void InitializeStackLevel(int level, int[] stack)
        {
            stack[level] = 0;
        }

        bool LevelHasSuccessor(int level, int[] stack)
        {
            if (stack[level] < n)
            {                
                return true;
            }
            return false;
        }

        void SetLevelValue(int level, int[] stack)
        {
            stack[level] = stack[level] + 1;
        }

        bool LevelIsValid(int level, int[] stack)
        {
            for (var i = 0; i < level; i++)
            {
                if (stack[i] == stack[level])
                {
                    return false;
                }
            }

            return true;
        }

        bool IsSolution(int level)
        {
            if (level == n - 1)
            {
                return true;
            }
            
            return false;
        }

        void PrintSolution()
        {
            for (var i = 0; i < n; i++)
            {
                Console.Write(stack[i] + " ");
            }
            Console.Write("\n");
        }

        public void Solve()
        {
            var level = 0; 
            var isValid = true;
            var hasSuccesor = true;

            InitializeStackLevel(level, stack);

            while (level >= 0)
            {
                do
                {
                    hasSuccesor = LevelHasSuccessor(level, stack);
                    if (hasSuccesor)
                    {
                        SetLevelValue(level, stack);
                        isValid = LevelIsValid(level, stack);
                    }
                } while (!(!hasSuccesor || (hasSuccesor && isValid)));

                if (hasSuccesor)
                { 
                    if (IsSolution(level))
                    {
                        PrintSolution();
                    }
                    else
                    {
                        level++;
                        InitializeStackLevel(level, stack);
                    }
                }
                else
                {
                    level--;
                }
            }
        }
    }
}
