IF NOT EXISTS (SELECT 1 FROM DBO.[User])
BEGIN
	INSERT INTO DBO.[User] (FirstName, Surname, Username, [Password], [Admin])
	VALUES 
	('Joe', 'Osborne','JoesUsername','Ozzy1',1),
	('Mark','Zucc','LizardMan','MetaIsCool',0),
	('Tony','Stark','TonyS','Peppa',0),
	('Elon','Musk','ElonM','MelonUsk',0);
END;