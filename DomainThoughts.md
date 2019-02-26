# Domain Actions
- Collect Seed (Entity Out: Seed Batch)
  - Record Seed Collection (Params: Site, Species, Date)

- Propagate Seed (Entity In: Seed Batch, Entity Out: Seed Tray)
  - Record Propagation (Params: Seed Batch, Date, No. of trays)

- Pot on seedlings (Entity in: Seed Tray, Entity Out: Plant Stock of given product type?)
  - Record potting (Params: List Of [Seed Tray (includes Species etc), Product Type, Quantity])

- Propagate cuttings?

- Discard seed trays on completion or failure

- Throw out plants that have died

- Sell plants
- Record sale (Params: Species, Product Type, Quantity, Date, Event?) 

- Give away plants
- Record gift (Params: Species, Product Type, Quantity, Date, Event?) 

- Receive plants from other people

# Domain Aggregates

- Current items
- Genus: Ok on it's own, has meaning
- Species: needs genus to be meaningful
- SeedBatch: needs genus/species to be meaningful, source site adds extra detail
- SeedTray: needs genus/species to be meaningful, source seedbatch adds extra detail
- Site: has meaning on it's own (provided location information is included)
- PlantStock: needs genus/species, quantity and product type (value object) to be meaningful, source (e.g. seed tray or other) adds extra detail
- JournalEntry: as for PlantStock, plus needs journal entry type to define action
- ProductPrice: value object?
- ProductType: value object
- PriceListType: value object
- JournalEntryType: value object

