Driver driver = new Driver();

// driver.RunSerialMemoFibonnaciRandomSum();
driver.RunSerialDPFibonnaciRandomSum();
driver.RunParallelDPFibonnaciRandomSum();
driver.RunSerialLazyFibonnaciRandomSum();
driver.RunParallelLazyFibonnaciRandomSum();

driver.ValidateSums();