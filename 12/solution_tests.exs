ExUnit.start()

defmodule Solution_tests do
  use ExUnit.Case, async: true
  import Triangular, only: [generate: 0 ]

  test "returns correct trangular numbers" do
    assert generate |>  Enum.take(7) |> Enum.to_list() == [1, 3, 6, 10, 15, 21, 28]
  end
end
