CREATE VIEW [dbo].[Plant]
	AS SELECT S.Id, G.LatinName, S.SpecificName, S.CommonName, S.Description, S.PropagationTime, S.Native FROM dbo.Species S
	left join dbo.Genus G
	ON S.GenusId = G.Id
