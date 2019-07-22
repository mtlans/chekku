namespace Chekku
{
    class Student
    {
        private string s_id = "";
        string s_name = "";

        public Student(string id, string name)
        {
            s_id = id;
            s_name = name;
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
    }
}
