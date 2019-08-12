namespace Chekku
{
    class Student
    {
        private string s_id = "";
        string s_name = "";
        int score = 0;

        public Student(string id)
        {
            s_id = id;
        }

        public Student(string id, int score)
        {
            s_id = id;
            this.score = score;
        }

        public string Id
        {
            get { return s_id; }
            set { s_id = value; }
        }

        public string Name
        {
            get { return s_name; }
            set { s_name = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
