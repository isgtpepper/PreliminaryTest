USE PreliminaryTest;
GO

SELECT B.Business, ISNULL(P.StreetNo, '') AS StreetNo, P.Street, P.PostCode, SUM(F.FootfallCount) AS FootfallCount
FROM Businesses AS B
WITH (HOLDLOCK)
INNER JOIN Premisses AS P ON B.Id = P.BusinessId
LEFT JOIN Footfall AS F ON F.PremissesId = P.Id
GROUP BY B.Business, P.StreetNo, P.Street, P.PostCode
