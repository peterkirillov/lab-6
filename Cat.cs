using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab6_2
{
    class Cat
    {
        String front_laps;
        String back_laps;
        String ears;
        String tail;

        public int years;

        public Cat()
        {
        }

        public Cat(string fl, string bl, string ear, string ctail, int year)
        {
            front_laps = fl;
            back_laps = bl;
            ears = ear;
            years = year;
            tail = ctail;
        }

        public int Cat_moves(int cur_pos, int steps)
        {
            int pos = cur_pos + steps;
            return pos;
        }

        [NewAttribute("Front claws")]
        public String Front_Laps
        {
            get
            {
                return front_laps;
            }
            set
            {
                front_laps = value;
            }
        }

        public String Back_Laps
        {
            get
            {
                return back_laps;
            }
            set
            {
                back_laps = value;
            }
        }

        public String Ears
        {
            get
            {
                return ears;
            }
            set
            {
                ears = value;
            }
        }

        [NewAttribute("Tail of a cat")]
        public String Tail
        {
            get
            {
                return tail;
            }
            set
            {
                tail = value;
            }
        }
    }
}