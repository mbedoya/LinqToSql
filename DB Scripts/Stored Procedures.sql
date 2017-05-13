-- https://sqlperformance.com/2015/01/t-sql-queries/pagination-with-offset-fetch
-- http://joelabrahamsson.com/my-favorite-way-to-do-paging-with-t-sql/



USE [Linq]
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 05/13/2017 11:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetCategories](@Page int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @PageSize int, @StartRow int, @EndRow int
	SET @PageSize = 2
	
	SET @StartRow = (@Page-1)*@PageSize + 1
	SET @EndRow = (@Page)*@PageSize

    ;WITH CTE_Categories AS (
		SELECT 
			ROW_NUMBER() OVER(ORDER BY CategoryId ASC) as idx,
			CategoryId,
			Name			
		FROM 
			Linq.dbo.CategoryDTOes
    )
    
    SELECT
		idx,CategoryId, Name
    FROM
		CTE_Categories
	WHERE
		idx BETWEEN @StartRow AND @EndRow
END
