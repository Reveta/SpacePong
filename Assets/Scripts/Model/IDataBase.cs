using System.Collections.Generic;

namespace Model {

	public interface IDataBase {
		void AddResult(UserResult userResult);

		List<UserResult> GetAllResult();
	}

}