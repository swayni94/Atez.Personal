﻿namespace Atez.Personal.Data.Entity
{
    public class Employee : BaseEntity
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string startdatework { get; set; }
        public int salary { get; set; }
        public int departmentid { get; set; }
        public int titleid { get; set; }
    }
}
