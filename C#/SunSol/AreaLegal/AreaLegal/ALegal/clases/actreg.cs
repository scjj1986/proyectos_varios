using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ALegal;
using System.ComponentModel;
using System.Text;

namespace ALegal
{
    public class actreg
    {
        public string nr { get; set; }

        public string tomo { get; set; }

        public string string_fcel { get; set; }

        public string string_fprot { get; set; }

        public DateTime fcel { get; set; }

        public DateTime fprot { get; set; }

        public string ptosatratar { get; set; }


    }
}
