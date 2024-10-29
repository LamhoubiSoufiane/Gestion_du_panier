// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    var currentQuantity = 0;

    function updateQuantity(productId, index) {
            var quantityLabel = document.getElementById('quantity-' + productId);
    var hiddenquantityInput = document.getElementById('hidden-quantity-' + productId);
    var currentQuantity = parseInt(quantityLabel.textContent);
    var newQuantity = Math.max(1, currentQuantity + index);

    quantityLabel.textContent = newQuantity;

    hiddenquantityInput.value = newQuantity;

    // Recalculer le total
    var totalCell = document.getElementById('total-' + productId);
    var price = parseFloat(totalCell.getAttribute('data-price'));
    totalCell.textContent = (price * newQuantity).toFixed(2) + ' Dh';
    recalculateTotal();
        }

    // Fonction pour recalculer le total du panier
    function recalculateTotal() {
            var totalElements = document.querySelectorAll('[id^="total-"]');
    var newTotalPrice = 0;

    totalElements.forEach(function (element) {
                var itemTotal = parseFloat(element.innerText);
    if (!isNaN(itemTotal)) {
        newTotalPrice += itemTotal;
                }
            });

    document.getElementById("totalPrice").innerText = newTotalPrice.toFixed(2);
        }

