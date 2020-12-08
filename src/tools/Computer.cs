using System;
using System.Collections.Generic;

namespace AOC.Tools
{
    public class Computer
    {
        private List<string> _program = new List<string>();
        private int _accumulator = 0;
        private int _address = 0;
        private HashSet<int> _instrCache = new HashSet<int>();

        public int Accumulator { get { return _accumulator; } }

        public void Load(string filePath)
        {
            var reader = FileIO.CreateProjFilePath(filePath);
            _program = reader.ReadAll();
        }

        public bool Run()
        {
            return Run(_program);
        }

        public bool Run(List<string> program)
        {
            _address = 0;
            _accumulator = 0;
            _instrCache.Clear();

            while(true)
            {
                if (_address >= program.Count) return true;
                var code = program[_address].Split(" ");
                var instruction = code[0];
                
                int modifier;
                if (!Int32.TryParse(code[1], out modifier)) return false;

                if (_instrCache.Contains(_address))
                {
                    return false;
                }
                else
                {
                    _instrCache.Add(_address);
                }

                switch(instruction)
                {
                    case "nop": 
                    {
                        _address++;
                    }
                    break;
                    
                    case "acc":
                    {
                        _accumulator += modifier;
                        _address++;
                    } 
                    break;

                    case "jmp":
                    {
                        _address += modifier;
                    }
                    break;

                    default: return false;
                }
            }
        }

        private List<string> ProgramCopy()
        {
            var res = new List<string>();

            foreach(var it in _program)
            {
                var str = new string(it);
                res.Add(str);
            }

            return res;
        }

        public int FindBug()
        {
            for (var i = 0; i < _program.Count; i++)
            {
                var instr = _program[i].Split(" ");
                if (instr[0] != "jmp" && instr[0] != "nop") continue;

                var modifProg = ProgramCopy();
                
                if (modifProg[i].IndexOf("jmp") >= 0)
                {
                    modifProg[i] = modifProg[i].Replace("jmp", "nop");
                }
                else
                {
                    modifProg[i] = modifProg[i].Replace("nop", "jmp");
                }

                if (Run(modifProg)) return i;
            }

            return -1;
        }
    }
}