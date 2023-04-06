namespace NoarJobAPI.Models
{
    public class MostSoughtJobBL
    {
        private int userID;
        private List<int> childCategoriesLst;
        private List<int> citiesLst;
        private List<int> typesLst;

        public int UserID { get => userID; set => userID = value; }
        public List<int> ChildCategoriesLst { get => childCategoriesLst; set => childCategoriesLst = value; }
        public List<int> CitiesLst { get => citiesLst; set => citiesLst = value; }
        public List<int> TypesLst { get => typesLst; set => typesLst = value; }
    }
}
