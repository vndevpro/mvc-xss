﻿DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'Demo.XBanking.Data.Migrations.Configuration'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '201510260742089_AddConfigurationEntity'
BEGIN
    CREATE TABLE [dbo].[Configurations] (
        [Id] [uniqueidentifier] NOT NULL,
        [Version] [nvarchar](max),
        [SetupDate] [datetime] NOT NULL,
        CONSTRAINT [PK_dbo.Configurations] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201510260742089_AddConfigurationEntity', N'Demo.XBanking.Data.Migrations.Configuration',  0x1F8B0800000000000400CD57CB6EDB3814DD0FD07F10B86A81D44CDA4D27905BA47652045327459516B3A5A52B87281F2A1F81FD6DB3984F9A5F984BBD2DD971921645E10D4DDE7B78EE9BFAEF9F7FE3776B29A23B30966B352527936312814A75C6D56A4ABCCB5FBE21EFDE3EFB233ECFE43AFADAC8BD0E72A8A9EC94DC3A579C526AD35B90CC4E244F8DB63A7793544BCA324D5F1D1FFF494F4E28200441AC288A3F7BE5B884F20FFE9D699542E13C130B9D81B0F53E9E24256A74C524D882A5302573907AF2F77BA6BE21C5C99C3946A233C119324940E424624A69C71CF23CFD62217146AB5552E00613379B02502E67C242CDFFB4137FA829C7AF8229B4536CA0526F9D968F043C795DFB860ED59FE461D2FA0EBD778E5E769B6075E9C1294147E77CE54D8D3FBCF174264C90DEE5E5C996EE513496386AF303D328FC8EA29917CE1B982AF0CE3071147DF24BC1D3BF6073A3BF819A2A2F449F3172C6B3AD0DDCFA647401C66D3E435EDB719991886EEBD1A162ABD6D3A98CFBE039AEAFF06EB614D0E603BD57BDB6ADC1C0BC42BB49B460EB8FA056EE764A7049A20BBE86ACD9A981BF288E15854ACEF883F724E07C81EE84E6A6B0BEC16239C038A65DB4C73980C1738C2B30F52D4DE0E6CB70026BB72319B07AEA7CB035F56DE21532F2DD955C96441D9FAA342783ECDBC5BEE5D9B5005AF580A657D03DCD225EB0A2408B7ACDA3DE8992AA73CC5E268F2F295961D0D4EEA8AC966D7B93D386AD60701A5C93C10537D6853A59B210BB59264762E3A8ECF17873DF4EC70FCBA78B43A316D695EAA13A1F82755EBD4043252857DA0C2DB3618F19E9974D9D09667694E74C0B2FD5BE12BF4FBBADCE3E44BBF9709C5EF5F5917ADB63AC980E5C320C001D4560D0BA8671BDAF308622EDED6D810C0A21AE93F2F0681D656925422274D21DCF4286261BEB405689927C1733C1D1DE4E60C114CFC1BAAABB132CA23783E9FCFB4C4A6A6D261E332E7FF99CF28A7FF7807E455E3907F3A3334BDD3193DE32F35CB2F58B3ED893E652866BF7B3E7D2B8513E62E61C1E39554223F7A546332ACEC3B1F5C4B134AEB298F69FB9F11C2C5F7510E1D1AB200D9776A08DCCA5CA75E37F34B6CFA811198467018E6144D899C15C61A9C3E314AC2DDF285F99F028722E97905DAA6BEF0AEFCEAC05B9149BBEBD31BDFFFE72F66E738EAF8BD26D3FC304A4C943525DABF79E8BACE57DB123A9F64084F4F900B85F0613DF6808B7DAB448575A3D10A876DF1C0A50A1FE6E401602C1ECB54AD81D3C851B3EA73EC28AA59BA659EE07391C886DB7C773CE5686495B6374FAE1D38D866FB7B7FF039DBFFF02ED0D0000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201510260801155_AddReleaseNotesOnConfigurationEntity'
BEGIN
    ALTER TABLE [dbo].[Configurations] ADD [ReleaseNotes] [nvarchar](max)
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201510260801155_AddReleaseNotesOnConfigurationEntity', N'Demo.XBanking.Data.Migrations.Configuration',  0x1F8B0800000000000400CD57CB6EDB3A10DD5FA0FF2068D502A999B49B36905BA4765204B74E8A282DBAA5A59142940F958FC0FEB6BBB89FD45FE8506F4B769CA40F14DED0E4CC9933C37950DFFFFB3F7ABB123CB8056D9892D3F06872180620139532994F4367B3E7AFC2B76F9EFC139DA662157C6EE45E7A39D494661ADE585B1C1362921B10D44C044BB4322AB39344094253455E1C1EBE26474704102244AC2088AE9CB44C40F907FFCE944CA0B08EF2854A819B7A1F4FE21235B8A0024C4113988673106AF2E51D955F91E2644E2D0D8313CE28328981676140A554965AE479FCC9406CB592795CE006E5D7EB02502EA3DC40CDFFB813BFAF2B872FBC2BA4536CA01267AC120F043C7A59C7860CD51F15E1B08D1D46EF14A36CD7DEEB3282D310039DB1DCE91A7F68F178C6B597DE16E5C986EE4130963868F303D3C8FF0E8299E3D669984A7056537E107C744BCE927F617DADBE829C4AC7799F3172C6B38D0DDCFAA85501DAAEAF20ABFD384FC3806CEA91A162ABD6D3A99C7BEF18AE2FD0365D7268F381DCA95EFBD660605EA1DF61B0A0AB0F20737B330D711906676C0569B353037F920C2B0A95AC767BED5C01076AE0425930BFDD580CD6157877D058F2EB6BACCC3DE18948975AE384C34CB19449D0B595264BE64B7F022BBB25F3B054EBE43335F54DE21532F2DD96C918A88E4FD507268354DFC6BEE5D9F51B52359CA631911D9D295AD0A2408F7A9DAADE09E2AA4DCD9EC70FAF5F516190C46C29E3966D6BC92A4D73189CFAD0A470C6B4B1BE2897D4DFDD2C1523B1F1ADEC8878636F6BE087B5DADD43A3E6D795EABEA63204EBA27A868E0A90B6F4195A66C38636D22F2708E5546FE90533C59D90BBFAC95DDA6D2BE843B49BF7C7D92CF53ED8E6C9FD117BF5DC87EB6D8FB1223208F2F04AC9E84E079D7798297795DA50A4B5DE96DCA0B4A23ACDF7BF0C46795F89840106E996A53EE7E3B5B120AAD48BBFF11967E86F27B0A09265606C359C422CCB5783C7C5DF33E88931297FC8B4FFE363D649F6CD01C61579650CF4CF8E5C794B757243F5534157CFFA608F1DAB3F05381A9D29AEEDAF1E9DE35EFE80B1B87F2A561582DC970ADDA8380F27EB2327E7B86C23D27FF64773302CEF20FC478084C41BED401B997399A926FEE86C9F512332B89E05588A37424F34261F4D2C1E27604CF98CFA4CB9439153B184F45C5E3A5B387B620C88255FF7FD8DC8DDF6CBE7C126E7E8B228C3F62B5C409ACC27D5A57CE7184F5BDE675B926A07844F9FF780FBE565E23312E1F2758B74A1E43D81EAF0CDA100E90BFA1A44C111CC5CCA98DEC263B8E18BEF03E4345937DD7737C8FE8BD80C7B346734D754981AA3D3F79FB2C47FCBBEF901FA772EFCFD0E0000 , N'6.1.3-40302')
END
