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

-  