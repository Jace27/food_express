declare @num int
declare @com nvarchar(max)
set @num = 1
while(@num < 5)
begin
set @com = 'select img_data.BulkColumn as data, ''some_text'' as add_data from OpenRowSet(BULK ''C:\img_import\logo-0'+convert(nvarchar(max),@num)+'.jpg'', SINGLE_BLOB) img_data'
insert files ([data], add_data) exec(@com)
set @num = @num + 1
end