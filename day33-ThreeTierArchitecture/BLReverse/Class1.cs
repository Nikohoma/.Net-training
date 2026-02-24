using ReverseDAL;

namespace BLReverse
{
    public class ReverseBL
    {

        public string ReverseString()
        {
            DALRevString d = new DALRevString();
            var resultFromDAL = d.strReverseDal();
            var output = new string(resultFromDAL.Reverse().ToArray());
            return output;
        }
    }
}
