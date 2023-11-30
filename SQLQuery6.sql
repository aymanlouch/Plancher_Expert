insert into Fourniture (Image)
select BulkColumn
from OPENROWSET
(
	Bulk 'C:\Users\louch\Documents\dotnet\Plancher_Expert\Plancher_Expert\wwwroot\Images\tapis_commercial.jpg',SINGLE_BLOB
)AS Image