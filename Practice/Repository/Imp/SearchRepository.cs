using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Imp
{
    public class SearchRepository : ISearchRepository
    {
        public IEnumerable<string> Search(string query)
        {
            List<string>    _list=new List<string>();
            _list.Add("R1");
            _list.Add("R21");
            _list.Add("R134");
            _list.Add("R14");
            _list.Add("R13");
            _list.Add("R134");
            return _list;
        }
    }
}
