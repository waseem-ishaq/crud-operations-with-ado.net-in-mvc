namespace crudSystemADO.Utility
{
	public static class ConnectionString
	{
		private static string cName = "Data Source=localhost; Initial Catalog=db_test; User ID=root; Password=1234";
		public static string CName
		{
			get => cName;
		}
	}
}
