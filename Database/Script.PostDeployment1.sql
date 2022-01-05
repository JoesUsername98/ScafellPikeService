IF NOT EXISTS (SELECT 1 FROM DBO.[User])
BEGIN
	INSERT INTO DBO.[User] (FirstName, Surname, Username, [Password])
	VALUES 
	('Joe', 'Osborne','JoesUsername','Ozzy1'),
	('Mark','Zucc','LizardMan','MetaIsCool'),
	('Tony','Stark','TonyS','Peppa'),
	('Elon','Musk','ElonM','MelonUsk');
END;