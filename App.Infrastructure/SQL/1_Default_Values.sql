 SET QUOTED_IDENTIFIER ON;

 INSERT INTO org.EventCategories (PublicId,[Name],[Description],DateCreated,DateModified,IsDeleted,IsActive)
 VALUES
  (NEWID(),'Default Category','This is the default category for events.', GETUTCDATE(), NULL,0,1);