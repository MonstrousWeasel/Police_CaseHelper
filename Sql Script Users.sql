select u.*
from AspNetRoles r
	inner join AspNetUserRoles ur on ur.RoleId = r.Id
	inner join AspNetUsers u on u.Id = ur.UserId
where r.Name = 'Administrator'