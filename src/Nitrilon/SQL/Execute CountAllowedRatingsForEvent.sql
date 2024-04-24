USE [NitrilonDB]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[CountAllowedRatingsForEvent]
		@EventId = NULL

SELECT	@return_value as 'Return Value'

GO
