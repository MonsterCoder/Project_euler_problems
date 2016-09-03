ExUnit.start()

defmodule Solution_tests do
  use ExUnit.Case, async: true
  import Triangular, only: [generate: 0, run: 1 ]
  import Factor, only: [of: 1]

  test "returns correct trangular numbers" do
    assert generate |>  Enum.take(7) |> Enum.to_list() == [1, 3, 6, 10, 15, 21, 28]
  end

  test "find factors for a number" do
    assert of(1)  == [1]
    assert of(3)  == [1, 3]
    assert of(28) == [1,2,4,7,14,28]
  end
  
  test 'return 28 as the first of more than 5 divisors' do
    assert run(5) == 28
  end
end
