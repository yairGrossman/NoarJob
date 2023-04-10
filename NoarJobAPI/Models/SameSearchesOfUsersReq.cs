namespace NoarJobAPI.Models
{
    public class SameSearchesOfUsersReq
    {
        private List<int> childCategoriesLst;
        private List<int> citiesLst;
        private List<int> typesLst = new List<int>();

        public List<int> ChildCategoriesLst { get => childCategoriesLst; set => childCategoriesLst = value; }
        public List<int> CitiesLst { get => citiesLst; set => citiesLst = value; }
        public List<int> TypesLst { get => typesLst; set => typesLst = value; }
    }
}
