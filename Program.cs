Driver driver = new Driver();

driver.RunSerialIterativeFibonnaciRandomSum();
driver.RunParallelIterativeFibonnaciRandomSum();
driver.RunSerialLazyFibonnaciRandomSum();
driver.RunParallelLazyFibonnaciRandomSum();

driver.ValidateSums();