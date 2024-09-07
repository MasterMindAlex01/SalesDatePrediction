export interface Result<T> {
  messages:   string[];
  Succeeded:  boolean;
  data:       T;
}
